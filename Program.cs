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