using PROG7311_POE_Part2_ST10257863.Data;

namespace PROG7311_POE_Part2_ST10257863.Services.Interfaces
{
	public interface IProductService
	{
		Task<List<Product>> GetFilteredProductsAsync(string searchString, int? categoryId, int? farmerId, string userId, bool isFarmer, bool isEmployee);
		Task<Farmer> GetFarmerByUserIdAsync(string userId);
		Task<List<Category>> GetCategoriesAsync();
		Task<List<Farmer>> GetFarmersWithUsersAsync();
		Task AddProductAsync(Product product);
		Task<Category> AddCategoryAsync(string categoryName);
	}
}