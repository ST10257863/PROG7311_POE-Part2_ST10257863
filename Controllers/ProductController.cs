using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_Part2_ST10257863.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
	[Authorize]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> ProductView(string searchString, int? categoryId, int? farmerId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			bool isFarmer = User.IsInRole("Farmer");
			bool isEmployee = User.IsInRole("Employee");

			var products = await _productService.GetFilteredProductsAsync(searchString, categoryId, farmerId, userId, isFarmer, isEmployee);

			ViewBag.IsFarmer = isFarmer;
			ViewBag.Farmers = isFarmer ? null : await _productService.GetFarmersWithUsersAsync();
			ViewBag.Categories = await _productService.GetCategoriesAsync();

			return View(products);
		}

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