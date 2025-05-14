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

		public DatabaseManagementController(
			IDatabaseManagementService databaseManagementService,
			SignInManager<ApplicationUser> signInManager)
		{
			_databaseManagementService = databaseManagementService;
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