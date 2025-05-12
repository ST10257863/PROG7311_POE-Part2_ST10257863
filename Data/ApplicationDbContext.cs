using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Farm> Farms
		{
			get; set;
		}
		public DbSet<Farmer> Farmers
		{
			get; set;
		}
		public DbSet<Employee> Employees
		{
			get; set;
		}
		public DbSet<Products> Products
		{
			get; set;
		}
		public DbSet<Customer> Customers
		{
			get; set;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			SeedFarmsAndProducts(builder);

			builder.Entity<ApplicationUser>()
				.HasOne(u => u.FarmerProfile)
				.WithOne(f => f.User)
				.HasForeignKey<Farmer>(f => f.UserId);

			builder.Entity<ApplicationUser>()
				.HasOne(u => u.EmployeeProfile)
				.WithOne(e => e.User)
				.HasForeignKey<Employee>(e => e.UserId);

			builder.Entity<ApplicationUser>()
				.HasOne(u => u.CustomerProfile)
				.WithOne(c => c.User)
				.HasForeignKey<Customer>(c => c.UserId);

			builder.Entity<Farm>()
				.HasMany(f => f.Farmers)
				.WithOne(fa => fa.Farm)
				.HasForeignKey(fa => fa.FarmId)
				.OnDelete(DeleteBehavior.Cascade); // Cascade delete Farmers

			builder.Entity<Farm>()
				.HasMany(f => f.Products)
				.WithOne(p => p.Farm)
				.HasForeignKey(p => p.FarmId)
				.OnDelete(DeleteBehavior.Cascade); // Cascade delete Products
		}
		private void SeedFarmsAndProducts(ModelBuilder modelBuilder)
		{
			var farms = new List<Farm>
	{
		new Farm { Id = 1, Name = "Oakridge Organic Farm", Location = "California, USA" },
		new Farm { Id = 2, Name = "Sunny Meadows Dairy", Location = "Free State, South Africa" },
		new Farm { Id = 3, Name = "Green Hills Citrus Estate", Location = "Limpopo, South Africa" },
		new Farm { Id = 4, Name = "Red Earth Livestock Farm", Location = "Texas, USA" },
		new Farm { Id = 5, Name = "Valley View Vineyard", Location = "Stellenbosch, South Africa" },
		new Farm { Id = 6, Name = "Cedar Ridge Poultry Farm", Location = "Mpumalanga, South Africa" },
		new Farm { Id = 7, Name = "Blue River Aquafarm", Location = "KwaZulu-Natal, South Africa" },
		new Farm { Id = 8, Name = "Mountain Edge Alpaca Farm", Location = "Chilean Andes" },
		new Farm { Id = 9, Name = "Riverbend Vegetable Farm", Location = "Oregon, USA" },
		new Farm { Id = 10, Name = "Karoo Honey & Herb Farm", Location = "Northern Cape, South Africa" }
	};

			modelBuilder.Entity<Farm>().HasData(farms);

			var productNames = new Dictionary<int, (string Category, List<string> Products)>
			{
				[1] = ("Organic Produce", new List<string> {
			"Organic Strawberries", "Organic Blueberries", "Organic Kale", "Organic Spinach", "Organic Lettuce",
			"Organic Broccoli", "Organic Carrots", "Organic Tomatoes", "Organic Cucumbers", "Organic Zucchini",
			"Organic Apples", "Organic Pears", "Organic Potatoes", "Organic Onions", "Organic Bell Peppers",
			"Organic Corn", "Organic Beets", "Organic Radish", "Organic Celery", "Organic Cauliflower"
		}),
				[2] = ("Dairy", new List<string> {
			"Fresh Whole Milk", "Skim Milk", "Yogurt", "Cheese", "Butter",
			"Cream", "Ice Cream", "Buttermilk", "Cottage Cheese", "Sour Cream",
			"Goat Milk", "Raw Milk", "Chocolate Milk", "Strawberry Milk", "Lactose-Free Milk",
			"Farm Eggs", "Free-range Chicken", "Chicken Sausages", "Beef Mince", "Dairy Cattle Manure"
		}),
				[3] = ("Citrus", new List<string> {
			"Oranges", "Naartjies", "Lemons", "Limes", "Grapefruits",
			"Clementines", "Blood Oranges", "Citrus Juice", "Citrus Marmalade", "Dried Orange Slices",
			"Orange Essential Oil", "Lemon Curd", "Citrus Zest Powder", "Lemonade Concentrate", "Citrus Pectin",
			"Candied Orange Peel", "Orange Soap", "Citrus Hand Sanitizer", "Citrus-flavored Honey", "Lemon Vinegar"
		}),
				[4] = ("Livestock", new List<string> {
			"Angus Beef", "Pork Chops", "Lamb Meat", "Goat Meat", "Chicken Meat",
			"Duck Meat", "Turkey Meat", "Eggs (Chicken)", "Duck Eggs", "Wool",
			"Cow Hides", "Leather", "Goat Milk", "Manure", "Honey (from beehives)",
			"Chicken Feet", "Bone Broth Packs", "Liver", "Pet Food", "Feathers"
		}),
				[5] = ("Wine", new List<string> {
			"Cabernet Sauvignon", "Merlot", "Shiraz", "Pinotage", "Chardonnay",
			"Sauvignon Blanc", "Rosé", "Sparkling Wine", "Wine Vinegar", "Grape Juice",
			"Raisins", "Table Grapes", "Grape Jam", "Grape Seed Oil", "Grape Seed Flour",
			"Red Wine Sauce", "Mulled Wine Mix", "Brandy", "Fortified Wine", "Wine-Infused Cheese"
		}),
				[6] = ("Poultry", new List<string> {
			"Chicken Broilers", "Layer Hens", "Chicken Eggs", "Duck Eggs", "Quail Eggs",
			"Quail Meat", "Chicken Wings", "Chicken Breasts", "Chicken Livers", "Chicken Gizzards",
			"Chicken Feed", "Chicken Compost", "Organic Chicken Fertilizer", "Dressed Duck", "Smoked Chicken",
			"Chicken Sausages", "Chicken Burgers", "Chicken Nuggets", "Frozen Chicken", "Feather Meal"
		}),
				[7] = ("Aquaculture", new List<string> {
			"Tilapia", "Catfish", "Trout", "Fresh Prawns", "Shrimp",
			"Crayfish", "Fish Fillets", "Smoked Fish", "Dried Fish", "Fish Oil",
			"Fish Meal", "Fish Sauce", "Aquarium Fish", "Ornamental Koi", "Freshwater Mussels",
			"Live Fish Feed", "Seaweed", "Fish Roe", "Fish Fertilizer", "Aquaponic Lettuce"
		}),
				[8] = ("Fiber", new List<string> {
			"White Alpaca Wool", "Black Alpaca Wool", "Brown Alpaca Wool", "Hand-Spun Yarn", "Wool Blankets",
			"Wool Scarves", "Wool Socks", "Alpaca Rugs", "Alpaca Hats", "Felt Sheets",
			"Wool Gloves", "Baby Alpaca Fiber", "Dyed Wool", "Wool Stuffed Toys", "Alpaca Wool Sweaters",
			"Alpaca Manure", "Alpaca Breeding Stock", "Wool Throws", "Wool Vests", "Wool Art Supplies"
		}),
				[9] = ("Vegetables", new List<string> {
			"Tomatoes", "Cucumbers", "Lettuce", "Carrots", "Cabbage",
			"Zucchini", "Green Beans", "Peas", "Corn", "Sweet Potatoes",
			"Spinach", "Bell Peppers", "Chili Peppers", "Butternut Squash", "Pumpkin",
			"Eggplant", "Artichokes", "Garlic", "Ginger", "Leeks"
		}),
				[10] = ("Herbs & Honey", new List<string> {
			"Wildflower Honey", "Karoo Fynbos Honey", "Beeswax", "Propolis", "Royal Jelly",
			"Honeycomb", "Lavender", "Rosemary", "Thyme", "Oregano",
			"Mint", "Sage", "Basil", "Herbal Tea Mix", "Essential Oils",
			"Dried Herbs", "Herbal Soap", "Honey Lip Balm", "Beeswax Candles", "Pollen Capsules"
		})
			};

			var random = new Random(1); // Use a fixed seed for deterministic results
			var allProducts = new List<Products>();
			int productId = 1;

			foreach (var farm in farms)
			{
				var (category, products) = productNames[farm.Id];
				foreach (var productName in products)
				{
					allProducts.Add(new Products
					{
						Id = productId++,
						Name = productName,
						Category = category,
						FarmId = farm.Id,
						ProductionDate = DateTime.Now.Date.AddDays(-random.Next(1, 365))
					});
				}
			}

			modelBuilder.Entity<Products>().HasData(allProducts);
		}
	}
}