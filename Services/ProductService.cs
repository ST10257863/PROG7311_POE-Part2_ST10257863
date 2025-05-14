using Microsoft.EntityFrameworkCore;
using PROG7311_POE_Part2_ST10257863.Data;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

namespace PROG7311_POE_Part2_ST10257863.Services
{
	/// <summary>
	/// Service class for handling product-related operations.
	/// </summary>
	public class ProductService : IProductService
	{
		private readonly ApplicationDbContext _context;

		/// <summary>
		/// Initializes a new instance of the ProductService class.
		/// </summary>
		/// <param name="context">The database context.</param>
		public ProductService(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieves a filtered list of products based on various criteria.
		/// </summary>
		/// <param name="searchString">The search string to filter products by name.</param>
		/// <param name="categoryId">The category ID to filter products.</param>
		/// <param name="farmerId">The farmer ID to filter products (for employees).</param>
		/// <param name="userId">The current user's ID.</param>
		/// <param name="isFarmer">Indicates if the current user is a farmer.</param>
		/// <param name="isEmployee">Indicates if the current user is an employee.</param>
		/// <returns>A list of filtered products.</returns>
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

		/// <summary>
		/// Retrieves a farmer by their user ID.
		/// </summary>
		/// <param name="userId">The user ID of the farmer.</param>
		/// <returns>The farmer associated with the given user ID.</returns>
		public async Task<Farmer> GetFarmerByUserIdAsync(string userId)
		{
			return await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);
		}

		/// <summary>
		/// Retrieves all categories.
		/// </summary>
		/// <returns>A list of all categories.</returns>
		public async Task<List<Category>> GetCategoriesAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		/// <summary>
		/// Retrieves all farmers with their associated user information.
		/// </summary>
		/// <returns>A list of farmers including their user details.</returns>
		public async Task<List<Farmer>> GetFarmersWithUsersAsync()
		{
			return await _context.Farmers.Include(f => f.User).ToListAsync();
		}

		/// <summary>
		/// Adds a new product to the database.
		/// </summary>
		/// <param name="product">The product to be added.</param>
		public async Task AddProductAsync(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Adds a new category to the database.
		/// </summary>
		/// <param name="categoryName">The name of the category to be added.</param>
		/// <returns>The newly created category.</returns>
		public async Task<Category> AddCategoryAsync(string categoryName)
		{
			var category = new Category { Name = categoryName };
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();
			return category;
		}
	}
}