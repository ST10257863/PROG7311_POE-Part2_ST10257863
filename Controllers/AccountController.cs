using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_Part2_ST10257863.Models;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
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

			var result = await _accountService.LoginAsync(model);

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
			await _accountService.LogoutAsync();
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

			var result = await _accountService.AddFarmerAsync(model);

			if (result.Succeeded)
			{
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