using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_Part2_ST10257863.Data;
using System.Threading.Tasks;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
	[Authorize(Roles = "Employee")]
	public class DatabaseManagementController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public DatabaseManagementController(
			ApplicationDbContext context,
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager,
			SignInManager<ApplicationUser> signInManager)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
		}

		public IActionResult DatabaseManagement()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetDatabase()
		{
			try
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

				// Sign out the current user
				await _signInManager.SignOutAsync();

				TempData["Message"] = "Database has been reset and repopulated successfully. You have been logged out.";
			}
			catch (Exception ex)
			{
				TempData["Error"] = $"An error occurred while resetting the database: {ex.Message}";
			}

			return RedirectToAction("Login", "Account");
		}

		private async Task SeedRolesAndTestUsersAsync()
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
	}
}