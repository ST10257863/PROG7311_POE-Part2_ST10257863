using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_Part2_ST10257863.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
	/// <summary>
	/// Controller responsible for handling product-related operations.
	/// Requires authorization for all actions.
	/// </summary>
	[Authorize]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		/// <summary>
		/// Initializes a new instance of the ProductController.
		/// </summary>
		/// <param name="productService">The product service dependency.</param>
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		/// <summary>
		/// Displays the product view with filtered products based on user role and search criteria.
		/// </summary>
		/// <param name="searchString">Optional search string to filter products by name.</param>
		/// <param name="categoryId">Optional category ID to filter products by category.</param>
		/// <param name="farmerId">Optional farmer ID to filter products by farmer (for employees).</param>
		/// <returns>The product view with filtered products.</returns>
		public async Task<IActionResult> ProductView(string searchString, int? categoryId, int? farmerId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			bool isFarmer = User.IsInRole("Farmer");
			bool isEmployee = User.IsInRole("Employee");

			var products = await _productService.GetFilteredProductsAsync(searchString, categoryId, farmerId, userId, isFarmer, isEmployee);

			ViewBag.IsFarmer = isFarmer;
			ViewBag.Farmers = isEmployee ? await _productService.GetFarmersWithUsersAsync() : null;
			ViewBag.Categories = await _productService.GetCategoriesAsync();

			return View(products);
		}

		/// <summary>
		/// Displays the add product view for farmers.
		/// </summary>
		/// <returns>The add product view or redirects to ProductView if farmer profile is not found.</returns>
		[HttpGet]
		[Authorize(Roles = "Farmer")]
		public async Task<IActionResult> AddProductView()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var farmer = await _productService.GetFarmerByUserIdAsync(userId);

			if (farmer == null)
			{
				TempData["Error"] = "Farmer profile not found for the current user.";
				return RedirectToAction("ProductView");
			}

			var product = new Product { FarmerId = farmer.Id };

			ViewBag.Categories = await _productService.GetCategoriesAsync();
			return View(product);
		}

		/// <summary>
		/// Handles the addition of a new product by a farmer.
		/// </summary>
		/// <param name="product">The product to be added.</param>
		/// <returns>Redirects to ProductView on success, or returns to AddProductView with errors.</returns>
		[HttpPost]
		[Authorize(Roles = "Farmer")]
		public async Task<IActionResult> AddProduct(Product product)
		{
			if (ModelState.IsValid)
			{
				await _productService.AddProductAsync(product);
				TempData["Message"] = "Product added successfully!";
				return RedirectToAction("ProductView");
			}
			else
			{
				TempData["Error"] = "An error occurred!";
			}

			ViewBag.Categories = await _productService.GetCategoriesAsync();

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
		/// Handles the addition of a new category by a farmer.
		/// </summary>
		/// <param name="categoryName">The name of the category to be added.</param>
		/// <returns>JSON result with the new category details or BadRequest if invalid.</returns>
		[HttpPost]
		[Authorize(Roles = "Farmer")]
		public async Task<IActionResult> AddCategory(string categoryName)
		{
			if (string.IsNullOrWhiteSpace(categoryName))
				return BadRequest("Category name is required.");

			var existingCategories = await _productService.GetCategoriesAsync();
			if (existingCategories.Any(c => c.Name == categoryName))
				return BadRequest("Category already exists.");

			var category = await _productService.AddCategoryAsync(categoryName);

			return Json(new
			{
				id = category.Id,
				name = category.Name
			});
		}
	}
}