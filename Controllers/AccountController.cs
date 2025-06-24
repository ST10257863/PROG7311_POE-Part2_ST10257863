using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_Part2_ST10257863.Models;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
    /// <summary>
    /// Controller responsible for handling user account-related operations.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        /// <summary>
        /// Initializes a new instance of the AccountController.
        /// </summary>
        /// <param name="accountService">The account service dependency.</param>
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Displays the login view.
        /// </summary>
        /// <returns>The login view.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            // Check if there's a success message in TempData
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            // Check if there's an error message in TempData
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }

            return View();
        }

        /// <summary>
        /// Handles the login process.
        /// </summary>
        /// <param name="model">The login view model containing user credentials.</param>
        /// <returns>Redirects to ProductView if login is successful, otherwise returns to the login view with errors.</returns>
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

        /// <summary>
        /// Displays the registration view for new users.
        /// </summary>
        /// <returns>The registration view.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Handles the registration process for new users.
        /// </summary>
        /// <param name="model">The register view model containing user credentials.</param>
        /// <returns>
        /// Redirects to the login view if registration is successful and displays a success message.
        /// Returns to the registration view with errors if the model state is not valid.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterAsync(model);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Registration successful. You can now log in.";
                    return RedirectToAction(nameof(Login));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        /// <summary>
        /// Handles the logout process.
        /// </summary>
        /// <returns>Redirects to the login view after logging out.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// Displays the add farmer view.
        /// </summary>
        /// <returns>The add farmer view.</returns>
        [HttpGet]
        [Authorize(Roles = "Employee")]
        public IActionResult AddFarmer() => View("AddFarmer");

        /// <summary>
        /// Handles the process of adding a new farmer account.
        /// </summary>
        /// <param name="model">The add farmer view model containing new farmer details.</param>
        /// <returns>Redirects to AddFarmer view with a success message if farmer is added successfully, otherwise returns to the view with errors.</returns>
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