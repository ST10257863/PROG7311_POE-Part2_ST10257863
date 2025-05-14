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
		private readonly IDatabaseManagementService _databaseManagementService;
		private readonly SignInManager<ApplicationUser> _signInManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="DatabaseManagementController"/> class.
		/// </summary>
		/// <param name="databaseManagementService">The service responsible for managing database operations.</param>
		/// <param name="signInManager">The sign-in manager for handling user authentication.</param>
		/// <remarks>
		/// This constructor injects the necessary dependencies for database management and user authentication.
		/// </remarks>
		public DatabaseManagementController(
			IDatabaseManagementService databaseManagementService,
			SignInManager<ApplicationUser> signInManager)
		{
			_databaseManagementService = databaseManagementService;
			_signInManager = signInManager;
		}

		/// <summary>
		/// Displays the database management view.
		/// </summary>
		/// <remarks>
		/// This action method is responsible for rendering the database management page.
		/// It doesn't perform any data manipulation or processing.
		/// </remarks>
		/// <returns>
		/// An <see cref="IActionResult"/> that renders the default view for database management.
		/// </returns>
		public IActionResult DatabaseManagement()
		{
			return View();
		}

		/// <summary>
		/// Resets the database, repopulates it, and signs out the current user.
		/// </summary>
		/// <remarks>
		/// This method is triggered by an HTTP POST request. It attempts to reset the database
		/// using the database management service, signs out the current user, and then redirects
		/// to the login page. If successful, a success message is stored in TempData. If an error
		/// occurs, an error message is stored instead.
		/// </remarks>
		/// <returns>
		/// A <see cref="Task{IActionResult}"/> representing the asynchronous operation.
		/// The result is a redirect to the "Login" action of the "Account" controller.
		/// </returns>
		[HttpPost]
		public async Task<IActionResult> ResetDatabase()
		{
			try
			{
				await _databaseManagementService.ResetDatabaseAsync();
				await _signInManager.SignOutAsync();

				TempData["SuccessMessage"] = "Database has been reset and repopulated successfully. You have been logged out.";
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = $"An error occurred while resetting the database: {ex.Message}";
			}

			return RedirectToAction("Login", "Account");
		}
	}
}