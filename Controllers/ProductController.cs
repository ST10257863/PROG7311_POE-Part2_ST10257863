using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_Part2_ST10257863.Data;
using Microsoft.EntityFrameworkCore;

namespace PROG7311_POE_Part2_ST10257863.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ProductController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult ProductView(string searchString, string category, int? farmId)
		{
			var products = _context.Products.Include(p => p.Farm).AsQueryable();

			// Filtering
			if (!string.IsNullOrEmpty(searchString))
			{
				products = products.Where(p => p.Name.Contains(searchString));
			}
			if (!string.IsNullOrEmpty(category))
			{
				products = products.Where(p => p.Category == category);
			}
			if (farmId.HasValue)
			{
				products = products.Where(p => p.FarmId == farmId.Value);
			}

			// For dropdowns
			ViewBag.Categories = _context.Products.Select(p => p.Category).Distinct().ToList();
			ViewBag.Farms = _context.Farms.ToList();

			return View(products.ToList());
		}
	}
}
