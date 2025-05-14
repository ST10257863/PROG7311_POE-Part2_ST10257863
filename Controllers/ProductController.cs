using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_Part2_ST10257863.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
	[Authorize]
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ProductController(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieves and filters products based on search criteria and user role.
		/// </summary>
		/// <param name="searchString">The string to search for in product names. If provided, filters products by name.</param>
		/// <param name="categoryId">The ID of the category to filter products by. If provided, filters products by category.</param>
		/// <param name="farmerId">The ID of the farmer to filter products by. Only used if the user is an Employee.</param>
		/// <returns>An IActionResult that renders the ProductView with the filtered list of products.</returns>
		public IActionResult ProductView(string searchString, int? categoryId, int? farmerId)
		{
			var products = _context.Products
				.Include(p => p.Farmer).ThenInclude(f => f.User)
				.Include(p => p.Category)
				.AsQueryable();

			// Filtering
			if (!string.IsNullOrEmpty(searchString))
			{
				products = products.Where(p => p.Name.Contains(searchString));
			}
			if (categoryId.HasValue)
			{
				products = products.Where(p => p.CategoryId == categoryId.Value);
			}

			bool isFarmer = User.IsInRole("Farmer");
			bool isEmployee = User.IsInRole("Employee");

			if (isFarmer)
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var farmer = _context.Farmers.FirstOrDefault(f => f.UserId == userId);
				if (farmer != null)
				{
					products = products.Where(p => p.FarmerId == farmer.Id);
				}
				ViewBag.IsFarmer = true;
				ViewBag.Farmers = null;
			}
			else if (isEmployee)
			{
				if (farmerId.HasValue)
				{
					products = products.Where(p => p.FarmerId == farmerId.Value);
				}
				ViewBag.IsFarmer = false;
				ViewBag.Farmers = _context.Farmers.Include(f => f.User).ToList();
			}
			else
			{
				// Default: show all products, no farmer filter
				ViewBag.IsFarmer = false;
				ViewBag.Farmers = _context.Farmers.Include(f => f.User).ToList();
			}

			// Use Categories table for dropdown/filter
			ViewBag.Categories = _context.Categories.ToList();

			return View(products.ToList());
		}

		/// <summary>
		/// Displays the view for adding a new product. This action is only accessible to users with the "Farmer" role.
		/// </summary>
		/// <remarks>
		/// This method retrieves the current user's farmer profile, creates a new Product instance with the farmer's ID,
		/// and populates the ViewBag with a list of categories for the view to use.
		/// </remarks>
		/// <returns>
		/// If the farmer profile is found:
		///     An IActionResult that renders the AddProductView with a new Product instance and categories in ViewBag.
		/// If the farmer profile is not found:
		///     A redirect to the ProductView action with an error message in TempData.
		/// </returns>
		[HttpGet]
		[Authorize(Roles = "Farmer")]
		public IActionResult AddProductView()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var farmer = _context.Farmers.FirstOrDefault(f => f.UserId == userId);

			if (farmer == null)
			{
				TempData["Error"] = "Farmer profile not found for the current user.";
				return RedirectToAction("ProductView");
			}

			var product = new Product { FarmerId = farmer.Id };

			ViewBag.Categories = _context.Categories.ToList();
			return View(product);
		}

		/// <summary>
		/// Adds a new product to the database.
		/// </summary>
		/// <remarks>
		/// This method is only accessible to users with the "Farmer" role.
		/// If the model state is valid, it adds the product to the database and redirects to the ProductView.
		/// If the model state is invalid, it repopulates the categories dropdown and returns to the AddProductView with error messages.
		/// </remarks>
		/// <param name="product">The Product object containing the details of the product to be added.</param>
		/// <returns>
		/// If successful, returns a redirect to the ProductView action.
		/// If unsuccessful, returns the AddProductView with the product object and error messages.
		/// </returns>
		[HttpPost]
		[Authorize(Roles = "Farmer")]
		public async Task<IActionResult> AddProduct(Product product)
		{
			if (ModelState.IsValid)
			{
				_context.Products.Add(product);
				await _context.SaveChangesAsync();
				TempData["Message"] = "Product added successfully!";
				return RedirectToAction("ProductView");
			}
			else
			{
				TempData["Error"] = "An error occurred!";
			}

			ViewBag.Categories = _context.Categories.ToList();

			foreach (var state in ModelState)
			{
				foreach (var error in state.Value.Errors)
				{
					Console.WriteLine($"{state.Key}: {error.ErrorMessage}");
					TempData["Error"] = error.ErrorMessage;
				}
			}
			return View("AddProductView", product);
		}

		/// <summary>
		/// Adds a new category to the database.
		/// </summary>
		/// <remarks>
		/// This method is only accessible to users with the "Farmer" role.
		/// It checks if the category name is valid and not already existing before adding it to the database.
		/// </remarks>
		/// <param name="categoryName">The name of the category to be added. Must not be null or whitespace.</param>
		/// <returns>
		/// If successful, returns a JSON result containing the id and name of the newly added category.
		/// If the category name is null or whitespace, returns a BadRequest with an error message.
		/// If the category already exists, returns a BadRequest with an error message.
		/// </returns>
		[HttpPost]
		[Authorize(Roles = "Farmer")]
		public async Task<IActionResult> AddCategory(string categoryName)
		{
			if (string.IsNullOrWhiteSpace(categoryName))
				return BadRequest("Category name is required.");

			if (_context.Categories.Any(c => c.Name == categoryName))
				return BadRequest("Category already exists.");

			var category = new Category { Name = categoryName };
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();

			return Json(new
			{
				id = category.Id,
				name = category.Name
			});
		}
	}
}