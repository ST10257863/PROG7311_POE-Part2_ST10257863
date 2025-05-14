using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_Part2_ST10257863.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ProductController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult ProductView(string searchString, string category, int? farmerId)
		{
			var products = _context.Products.Include(p => p.Farmer).ThenInclude(f => f.User).AsQueryable();

			// Filtering
			if (!string.IsNullOrEmpty(searchString))
			{
				products = products.Where(p => p.Name.Contains(searchString));
			}
			if (!string.IsNullOrEmpty(category))
			{
				products = products.Where(p => p.Category == category);
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

			ViewBag.Categories = _context.Products.Select(p => p.Category).Distinct().ToList();

			return View(products.ToList());
		}

		[HttpGet]
		[Authorize(Roles = "Farmer")]
		public IActionResult AddProductView()
		{
			ViewBag.Categories = _context.Products.Select(p => p.Category).Distinct().ToList();
			ViewBag.Farmers = _context.Farmers.ToList();
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Farmer")]
		public async Task<IActionResult> AddProduct(Products product)
		{
			// 1. Get the current user's ID
			var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

			// 2. Find the Farmer entity for this user
			var farmer = _context.Farmers.FirstOrDefault(f => f.UserId == userId);

			if (farmer == null)
			{
				TempData["Error"] = "Farmer profile not found for the current user.";
				// Repopulate dropdowns for the view if validation fails
				ViewBag.Categories = _context.Products.Select(p => p.Category).Distinct().ToList();
				ViewBag.Farmers = _context.Farmers.ToList();
				return View("AddProductView", product);
			}

			// 3. Assign the FarmerId to the product
			product.FarmerId = farmer.Id;

			if (ModelState.IsValid)
			{
				_context.Products.Add(product);
				await _context.SaveChangesAsync();
				TempData["Message"] = "Product added successfully!";
				return RedirectToAction("ProductView");
			}
			else
			{
				TempData["Error"] = "An error occured!";
			}

			// Repopulate dropdowns for the view if validation fails
			ViewBag.Categories = _context.Products.Select(p => p.Category).Distinct().ToList();

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
	}
}
