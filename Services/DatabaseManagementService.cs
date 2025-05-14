using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_Part2_ST10257863.Data;

public class DatabaseManagementService : IDatabaseManagementService
{
	private readonly ApplicationDbContext _context;
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;

	public DatabaseManagementService(
		ApplicationDbContext context,
		UserManager<ApplicationUser> userManager,
		RoleManager<IdentityRole> roleManager)
	{
		_context = context;
		_userManager = userManager;
		_roleManager = roleManager;
	}

	/// <summary>
	/// Resets the database by clearing all existing data and reseeding with initial roles and test users.
	/// </summary>
	/// <remarks>
	/// This method performs the following operations:
	/// 1. Removes all records from Products, Categories, Farmers, and Employees tables.
	/// 2. Removes all users and roles from the database.
	/// 3. Saves the changes to persist the deletions.
	/// 4. Reseeds the database with initial roles and test users.
	/// </remarks>
	/// <returns>
	/// A Task representing the asynchronous operation. The task completes when the database has been reset and reseeded.
	/// </returns>
	public async Task ResetDatabaseAsync()
	{
		// Clear all tables
		_context.Products.RemoveRange(_context.Products);
		_context.Categories.RemoveRange(_context.Categories);
		_context.Farmers.RemoveRange(_context.Farmers);
		_context.Employees.RemoveRange(_context.Employees);

		// Remove all users and roles
		var users = await _context.Users.ToListAsync();
		_context.Users.RemoveRange(users);
		var roles = await _context.Roles.ToListAsync();
		_context.Roles.RemoveRange(roles);

		await _context.SaveChangesAsync();

		// Reseed the database
		await SeedRolesAndTestUsersAsync();
		await SeedFarmersProductsAndCategoriesAsync();
	}

	/// <summary>
	/// Seeds the database with predefined roles and test users asynchronously.
	/// </summary>
	/// <remarks>
	/// This method performs the following operations:
	/// 1. Creates "Employee" and "Farmer" roles if they don't exist.
	/// 2. Creates test users for each role with predefined information.
	/// 3. Assigns the appropriate role to each test user.
	/// 4. Creates corresponding entries in the Farmer or Employee table for each user.
	/// </remarks>
	/// <returns>
	/// A Task representing the asynchronous operation. The task completes when roles and test users have been seeded.
	/// </returns>
	public async Task SeedRolesAndTestUsersAsync()
	{

		string[] roleNames = { "Employee", "Farmer" };
		string defaultPassword = "Test@123"; // Change as needed

		// Ensure roles exist
		foreach (var roleName in roleNames)
		{
			if (!await _roleManager.RoleExistsAsync(roleName))
			{
				await _roleManager.CreateAsync(new IdentityRole(roleName));
			}
		}

		// Test users to seed
		var testUsers = new[]
		{
				new { Email = "employee@test.com", Role = "Employee", FirstName = "Test", LastName = "Employee", UserType = ApplicationUser.UserTypeEnum.Employee },
				new { Email = "farmer@test.com", Role = "Farmer", FirstName = "Test", LastName = "Farmer", UserType = ApplicationUser.UserTypeEnum.Farmer },
			};

		foreach (var testUser in testUsers)
		{
			var user = new ApplicationUser
			{
				UserName = testUser.Email,
				Email = testUser.Email,
				FirstName = testUser.FirstName,
				LastName = testUser.LastName,
				UserType = testUser.UserType
			};
			var result = await _userManager.CreateAsync(user, defaultPassword);
			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, testUser.Role);

				// Create corresponding entry in Farmer or Employee table
				if (testUser.Role == "Farmer")
				{
					var farmer = new Farmer { UserId = user.Id };
					_context.Farmers.Add(farmer);
				}
				else if (testUser.Role == "Employee")
				{
					var employee = new Employee { UserId = user.Id };
					_context.Employees.Add(employee);
				}

				await _context.SaveChangesAsync();
			}
		}
	}

	/// <summary>
	/// Seeds the database with farmers, products, and categories.
	/// </summary>
	/// <remarks>
	/// This method creates:
	/// - 10 farmers with linked entries in the Farmer table
	/// - 5 products for each farmer
	/// - Relevant categories for the products
	/// </remarks>
	/// <returns>A Task representing the asynchronous operation.</returns>
	public async Task SeedFarmersProductsAndCategoriesAsync()
	{
		// Create categories
		var categories = new[]
		{
		"Fruits", "Vegetables", "Grains", "Dairy", "Meat"
	};

		foreach (var categoryName in categories)
		{
			if (!await _context.Categories.AnyAsync(c => c.Name == categoryName))
			{
				_context.Categories.Add(new Category { Name = categoryName });
			}
		}
		await _context.SaveChangesAsync();

		// Create 10 farmers
		for (int i = 1; i <= 10; i++)
		{
			var user = new ApplicationUser
			{
				UserName = $"farmer{i}@example.com",
				Email = $"farmer{i}@example.com",
				FirstName = $"Farmer{i}",
				LastName = $"Example",
				UserType = ApplicationUser.UserTypeEnum.Farmer
			};

			var result = await _userManager.CreateAsync(user, "Farmer@123");
			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, "Farmer");

				var farmer = new Farmer { UserId = user.Id };
				_context.Farmers.Add(farmer);
				await _context.SaveChangesAsync();

				// Create 5 products for each farmer
				var random = new Random();
				for (int j = 1; j <= 5; j++)
				{
					var category = await _context.Categories.OrderBy(c => Guid.NewGuid()).FirstAsync();
					var product = new Product
					{
						Name = $"{category.Name} Product {j}",
						FarmerId = farmer.Id,
						CategoryId = category.Id,
						ProductionDate = DateTime.Now.AddDays(-random.Next(1, 30))
					};
					_context.Products.Add(product);
				}
				await _context.SaveChangesAsync();
			}
		}
	}
}