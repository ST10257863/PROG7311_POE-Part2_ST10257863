using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_Part2_ST10257863.Data;
using PROG7311_POE_Part2_ST10257863.Models;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _context;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager,
			ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_context = context;
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login() => View();

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View(model);
			}

			var result = await _signInManager.PasswordSignInAsync(
				user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

			if (result.Succeeded)
			{
				return RedirectToAction("ProductView", "Product");
			}

			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login", "Account");
		}


		[HttpGet]
		[Authorize(Roles = "Employee")]
		public IActionResult AddFarmer() => View("AddFarmer");

		[HttpPost]
		[Authorize(Roles = "Employee")]
		public async Task<IActionResult> AddFarmer(AddFarmerViewModel model)
		{
			if (!ModelState.IsValid)
				return View("AddFarmer", model);

			var existingUser = await _userManager.FindByEmailAsync(model.Email);
			if (existingUser != null)
			{
				ModelState.AddModelError("Email", "Email is already registered.");
				return View("AddFarmer", model);
			}

			var user = new ApplicationUser
			{
				UserName = model.Email,
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				UserType = ApplicationUser.UserTypeEnum.Farmer
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				// Ensure the "Farmer" role exists
				if (!await _roleManager.RoleExistsAsync("Farmer"))
				{
					await _roleManager.CreateAsync(new IdentityRole("Farmer"));
				}

				// Assign the "Farmer" role
				await _userManager.AddToRoleAsync(user, "Farmer");

				// Add to Farmer table
				var farmer = new Farmer
				{
					UserId = user.Id
				};
				_context.Farmers.Add(farmer);
				await _context.SaveChangesAsync();

				TempData["SuccessMessage"] = "Farmer account created successfully.";
				return RedirectToAction("AddFarmer");
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}

			return View("AddFarmer", model);
		}
	}
}
