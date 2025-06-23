using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_Part2_ST10257863.Models;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging information within the controller.</param>
        /// <remarks>
        /// This constructor injects an ILogger instance to enable logging capabilities in the HomeController.
        /// </remarks>
        public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

        /// <summary>
        /// Handles and displays error information when an error occurs in the application.
        /// </summary>
        /// <remarks>
        /// This action method is decorated with a ResponseCache attribute to prevent caching of error pages.
        /// It creates and returns an ErrorViewModel with a unique request identifier.
        /// </remarks>
        /// <returns>
        /// An IActionResult that renders the Error view with an ErrorViewModel containing error details.
        /// The view displays information about the error, including a unique request identifier.
        /// </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
