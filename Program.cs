using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_Part2_ST10257863.Data;
using PROG7311_POE_Part2_ST10257863.Services;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// --- Configure Services ---
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var initService = scope.ServiceProvider.GetRequiredService<IInitializationService>();
    await initService.InitializeAsync();
}

// --- Configure Middleware ---
ConfigureMiddleware(app, app.Environment);

app.Run();

/// <summary>
/// Configures the services for the application.
/// </summary>
/// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
/// <param name="configuration">The configuration of the application.</param>
/// <remarks>
/// This method sets up various services including:
/// - Database context
/// - Identity system
/// - MVC and Razor Pages
/// - Authorization policies
/// - Cookie configuration
/// - Custom application services
/// </remarks>
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	// Database context
	var connectionString = configuration.GetConnectionString("ApplicationDbContextConnection");
	services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

	// Identity
	services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
		.AddEntityFrameworkStores<ApplicationDbContext>()
		.AddDefaultTokenProviders();

	// MVC & Razor Pages
	services.AddControllersWithViews();
	services.AddRazorPages(options =>
	{
		options.Conventions.AuthorizeFolder("/");
		options.Conventions.AllowAnonymousToPage("/Account/Login");
	});

	// Authorization policies
	services.AddAuthorizationBuilder()
		.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("Employee"))
		.AddPolicy("RequireFarmerRole", policy => policy.RequireRole("Farmer"));

	// Cookie configuration
	services.ConfigureApplicationCookie(options =>
	{
		options.LoginPath = "/Account/Login";
		options.AccessDeniedPath = "/Account/AccessDenied";
	});

	// Services
	services.AddScoped<IAccountService, AccountService>();
	services.AddScoped<IProductService, ProductService>();
	services.AddScoped<IDatabaseManagementService, DatabaseManagementService>();
    services.AddScoped<IInitializationService, InitializationService>();
}

/// <summary>
/// Configures the middleware pipeline for the application.
/// </summary>
/// <param name="app">The <see cref="WebApplication"/> to configure.</param>
/// <param name="env">The <see cref="IWebHostEnvironment"/> representing the hosting environment.</param>
/// <remarks>
/// This method sets up the middleware components in the following order:
/// 1. Exception handling and HSTS (in non-development environments)
/// 2. HTTPS redirection
/// 3. Static file serving
/// 4. Routing
/// 5. Authentication
/// 6. Authorization
/// 7. Default controller route
/// </remarks>
void ConfigureMiddleware(WebApplication app, IWebHostEnvironment env)
{
	if (!env.IsDevelopment())
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
}