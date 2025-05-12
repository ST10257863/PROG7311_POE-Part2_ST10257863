using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_Part2_ST10257863.Data;

var builder = WebApplication.CreateBuilder(args);

// Retrieve the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString)); // Use the connection string from appsettings

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
	options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorizationBuilder()
	.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("Employee"))
	.AddPolicy("RequireFarmerRole", policy => policy.RequireRole("Farmer"))
	.AddPolicy("RequireCustomerRole", policy => policy.RequireRole("Customer"));



var app = builder.Build();

// Configure the HTTP request pipeline.
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
	pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed roles and users


//using (var scope = app.Services.CreateScope())
//{
//	var services = scope.ServiceProvider;
//	await SeedRolesAsync(services);
//}

app.Run();

//async Task SeedRolesAsync(IServiceProvider serviceProvider)
//{
//	var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//	string[] roleNames = { "Employee", "Farmer", "Customer" };

//	foreach (var roleName in roleNames)
//	{
//		if (!await roleManager.RoleExistsAsync(roleName))
//		{
//			await roleManager.CreateAsync(new IdentityRole(roleName));
//		}
//	}
//}