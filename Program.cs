using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_Part2_ST10257863.Data;
using PROG7311_POE_Part2_ST10257863.Services;

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

// Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IDatabaseManagementService, DatabaseManagementService>();

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

app.Run();
