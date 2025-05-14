using Microsoft.EntityFrameworkCore;
using PROG7311_POE_Part2_ST10257863.Data;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

namespace PROG7311_POE_Part2_ST10257863.Services
{
	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext _context;

		public ProductService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<Product>> GetFilteredProductsAsync(string searchString, int? categoryId, int? farmerId, string userId, bool isFarmer, bool isEmployee)
		{
			var products = _context.Products
				.Include(p => p.Farmer).ThenInclude(f => f.User)
				.Include(p => p.Category)
				.AsQueryable();

			if (!string.IsNullOrEmpty(searchString))
			{
				products = products.Where(p => p.Name.Contains(searchString));
			}
			if (categoryId.HasValue)
			{
				products = products.Where(p => p.CategoryId == categoryId.Value);
			}

			if (isFarmer)
			{
				var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);
				if (farmer != null)
				{
					products = products.Where(p => p.FarmerId == farmer.Id);
				}
			}
			else if (isEmployee && farmerId.HasValue)
			{
				products = products.Where(p => p.FarmerId == farmerId.Value);
			}

			return await products.ToListAsync();
		}

		public async Task<Farmer> GetFarmerByUserIdAsync(string userId)
		{
			return await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);
		}

		public async Task<List<Category>> GetCategoriesAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<List<Farmer>> GetFarmersWithUsersAsync()
		{
			return await _context.Farmers.Include(f => f.User).ToListAsync();
		}

		public async Task AddProductAsync(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
		}

		public async Task<Category> AddCategoryAsync(string categoryName)
		{
			var category = new Category { Name = categoryName };
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();
			return category;
		}
	}
}