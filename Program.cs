using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_Part2_ST10257863.Data;

var builder = WebApplication.CreateBuilder(args);

// --- Configure Services ---

// Database context
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
	options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

// MVC & Razor Pages
builder.Services.AddControllersWithViews();

// Authorization policies
builder.Services.AddAuthorizationBuilder()
	.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("Employee"))
	.AddPolicy("RequireFarmerRole", policy => policy.RequireRole("Farmer"));

builder.Services.AddRazorPages(options =>
{
	options.Conventions.AuthorizeFolder("/"); // Require auth for all pages
	options.Conventions.AllowAnonymousToPage("/Account/Login"); // Allow anonymous access to login
});

//Redirect on Access Denied or Unauthorized
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Account/Login";
	options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();

// --- Configure Middleware ---

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=Login}/{id?}");

//// --- Seed roles and test users ---
//using (var scope = app.Services.CreateScope())
//{
//	var services = scope.ServiceProvider;
//	await SeedRolesAndTestUsersAsync(services);
//}

app.Run();
//async Task SeedRolesAndTestUsersAsync(IServiceProvider serviceProvider)
//{
//	var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//	var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//	var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

//	string[] roleNames = { "Employee", "Farmer" };
//	string defaultPassword = "Test@123"; // Change as needed

//	// Ensure roles exist
//	foreach (var roleName in roleNames)
//	{
//		if (!await roleManager.RoleExistsAsync(roleName))
//		{
//			await roleManager.CreateAsync(new IdentityRole(roleName));
//		}
//	}

//	// Test users to seed
//	var testUsers = new[]
//	{
//		new { Email = "employee@test.com", Role = "Employee", FirstName = "Test", LastName = "Employee", UserType = ApplicationUser.UserTypeEnum.Employee },
//		new { Email = "farmer@test.com", Role = "Farmer", FirstName = "Test", LastName = "Farmer", UserType = ApplicationUser.UserTypeEnum.Farmer },
//	};

//	foreach (var testUser in testUsers)
//	{
//		var user = await userManager.FindByEmailAsync(testUser.Email);
//		if (user == null)
//		{
//			user = new ApplicationUser
//			{
//				UserName = testUser.Email,
//				Email = testUser.Email,
//				FirstName = testUser.FirstName,
//				LastName = testUser.LastName,
//				UserType = testUser.UserType
//			};
//			var result = await userManager.CreateAsync(user, defaultPassword);
//			if (result.Succeeded)
//			{
//				await userManager.AddToRoleAsync(user, testUser.Role);

//				// Create corresponding entry in Farmer or Employee table
//				if (testUser.Role == "Farmer")
//				{
//					var farmer = new Farmer { UserId = user.Id };
//					context.Farmers.Add(farmer);
//				}
//				else if (testUser.Role == "Employee")
//				{
//					var employee = new Employee { UserId = user.Id };
//					context.Employees.Add(employee);
//				}

//				await context.SaveChangesAsync();
//			}
//		}
//		else
//		{
//			// Ensure user is in the correct role
//			if (!await userManager.IsInRoleAsync(user, testUser.Role))
//			{
//				await userManager.AddToRoleAsync(user, testUser.Role);
//			}

//			// Ensure corresponding entry exists in Farmer or Employee table
//			if (testUser.Role == "Farmer" && !context.Farmers.Any(f => f.UserId == user.Id))
//			{
//				var farmer = new Farmer { UserId = user.Id };
//				context.Farmers.Add(farmer);
//				await context.SaveChangesAsync();
//			}
//			else if (testUser.Role == "Employee" && !context.Employees.Any(e => e.UserId == user.Id))
//			{
//				var employee = new Employee { UserId = user.Id };
//				context.Employees.Add(employee);
//				await context.SaveChangesAsync();
//			}
//		}
//	}
//}