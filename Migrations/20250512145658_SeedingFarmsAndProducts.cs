using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PROG7311_POE_Part2_ST10257863.Migrations
{
    /// <inheritdoc />
    public partial class SeedingFarmsAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			// Delete all Products first (due to FK constraint), then Farms
			migrationBuilder.Sql("DELETE FROM [Products]");
			migrationBuilder.Sql("DELETE FROM [Farms]");

			migrationBuilder.InsertData(
                table: "Farms",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "California, USA", "Oakridge Organic Farm" },
                    { 2, "Free State, South Africa", "Sunny Meadows Dairy" },
                    { 3, "Limpopo, South Africa", "Green Hills Citrus Estate" },
                    { 4, "Texas, USA", "Red Earth Livestock Farm" },
                    { 5, "Stellenbosch, South Africa", "Valley View Vineyard" },
                    { 6, "Mpumalanga, South Africa", "Cedar Ridge Poultry Farm" },
                    { 7, "KwaZulu-Natal, South Africa", "Blue River Aquafarm" },
                    { 8, "Chilean Andes", "Mountain Edge Alpaca Farm" },
                    { 9, "Oregon, USA", "Riverbend Vegetable Farm" },
                    { 10, "Northern Cape, South Africa", "Karoo Honey & Herb Farm" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "FarmId", "Name", "ProductionDate" },
                values: new object[,]
                {
                    { 1, "Organic Produce", 1, "Organic Strawberries", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "Organic Produce", 1, "Organic Blueberries", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "Organic Produce", 1, "Organic Kale", new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, "Organic Produce", 1, "Organic Spinach", new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, "Organic Produce", 1, "Organic Lettuce", new DateTime(2024, 9, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, "Organic Produce", 1, "Organic Broccoli", new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, "Organic Produce", 1, "Organic Carrots", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, "Organic Produce", 1, "Organic Tomatoes", new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, "Organic Produce", 1, "Organic Cucumbers", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, "Organic Produce", 1, "Organic Zucchini", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, "Organic Produce", 1, "Organic Apples", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 12, "Organic Produce", 1, "Organic Pears", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 13, "Organic Produce", 1, "Organic Potatoes", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 14, "Organic Produce", 1, "Organic Onions", new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 15, "Organic Produce", 1, "Organic Bell Peppers", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 16, "Organic Produce", 1, "Organic Corn", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 17, "Organic Produce", 1, "Organic Beets", new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 18, "Organic Produce", 1, "Organic Radish", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 19, "Organic Produce", 1, "Organic Celery", new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 20, "Organic Produce", 1, "Organic Cauliflower", new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 21, "Dairy", 2, "Fresh Whole Milk", new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 22, "Dairy", 2, "Skim Milk", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 23, "Dairy", 2, "Yogurt", new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 24, "Dairy", 2, "Cheese", new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 25, "Dairy", 2, "Butter", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 26, "Dairy", 2, "Cream", new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 27, "Dairy", 2, "Ice Cream", new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 28, "Dairy", 2, "Buttermilk", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 29, "Dairy", 2, "Cottage Cheese", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 30, "Dairy", 2, "Sour Cream", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 31, "Dairy", 2, "Goat Milk", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 32, "Dairy", 2, "Raw Milk", new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 33, "Dairy", 2, "Chocolate Milk", new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 34, "Dairy", 2, "Strawberry Milk", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 35, "Dairy", 2, "Lactose-Free Milk", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 36, "Dairy", 2, "Farm Eggs", new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 37, "Dairy", 2, "Free-range Chicken", new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 38, "Dairy", 2, "Chicken Sausages", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 39, "Dairy", 2, "Beef Mince", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 40, "Dairy", 2, "Dairy Cattle Manure", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 41, "Citrus", 3, "Oranges", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 42, "Citrus", 3, "Naartjies", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 43, "Citrus", 3, "Lemons", new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 44, "Citrus", 3, "Limes", new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 45, "Citrus", 3, "Grapefruits", new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 46, "Citrus", 3, "Clementines", new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 47, "Citrus", 3, "Blood Oranges", new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 48, "Citrus", 3, "Citrus Juice", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 49, "Citrus", 3, "Citrus Marmalade", new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 50, "Citrus", 3, "Dried Orange Slices", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 51, "Citrus", 3, "Orange Essential Oil", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 52, "Citrus", 3, "Lemon Curd", new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 53, "Citrus", 3, "Citrus Zest Powder", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 54, "Citrus", 3, "Lemonade Concentrate", new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 55, "Citrus", 3, "Citrus Pectin", new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 56, "Citrus", 3, "Candied Orange Peel", new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 57, "Citrus", 3, "Orange Soap", new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 58, "Citrus", 3, "Citrus Hand Sanitizer", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 59, "Citrus", 3, "Citrus-flavored Honey", new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 60, "Citrus", 3, "Lemon Vinegar", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 61, "Livestock", 4, "Angus Beef", new DateTime(2024, 9, 21, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 62, "Livestock", 4, "Pork Chops", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 63, "Livestock", 4, "Lamb Meat", new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 64, "Livestock", 4, "Goat Meat", new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 65, "Livestock", 4, "Chicken Meat", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 66, "Livestock", 4, "Duck Meat", new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 67, "Livestock", 4, "Turkey Meat", new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 68, "Livestock", 4, "Eggs (Chicken)", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 69, "Livestock", 4, "Duck Eggs", new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 70, "Livestock", 4, "Wool", new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 71, "Livestock", 4, "Cow Hides", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 72, "Livestock", 4, "Leather", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 73, "Livestock", 4, "Goat Milk", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 74, "Livestock", 4, "Manure", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 75, "Livestock", 4, "Honey (from beehives)", new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 76, "Livestock", 4, "Chicken Feet", new DateTime(2024, 5, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 77, "Livestock", 4, "Bone Broth Packs", new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 78, "Livestock", 4, "Liver", new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 79, "Livestock", 4, "Pet Food", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 80, "Livestock", 4, "Feathers", new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 81, "Wine", 5, "Cabernet Sauvignon", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 82, "Wine", 5, "Merlot", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 83, "Wine", 5, "Shiraz", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 84, "Wine", 5, "Pinotage", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 85, "Wine", 5, "Chardonnay", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 86, "Wine", 5, "Sauvignon Blanc", new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 87, "Wine", 5, "Rosé", new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 88, "Wine", 5, "Sparkling Wine", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 89, "Wine", 5, "Wine Vinegar", new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 90, "Wine", 5, "Grape Juice", new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 91, "Wine", 5, "Raisins", new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 92, "Wine", 5, "Table Grapes", new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 93, "Wine", 5, "Grape Jam", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 94, "Wine", 5, "Grape Seed Oil", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 95, "Wine", 5, "Grape Seed Flour", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 96, "Wine", 5, "Red Wine Sauce", new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 97, "Wine", 5, "Mulled Wine Mix", new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 98, "Wine", 5, "Brandy", new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 99, "Wine", 5, "Fortified Wine", new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 100, "Wine", 5, "Wine-Infused Cheese", new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 101, "Poultry", 6, "Chicken Broilers", new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 102, "Poultry", 6, "Layer Hens", new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 103, "Poultry", 6, "Chicken Eggs", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 104, "Poultry", 6, "Duck Eggs", new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 105, "Poultry", 6, "Quail Eggs", new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 106, "Poultry", 6, "Quail Meat", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 107, "Poultry", 6, "Chicken Wings", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 108, "Poultry", 6, "Chicken Breasts", new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 109, "Poultry", 6, "Chicken Livers", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 110, "Poultry", 6, "Chicken Gizzards", new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 111, "Poultry", 6, "Chicken Feed", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 112, "Poultry", 6, "Chicken Compost", new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 113, "Poultry", 6, "Organic Chicken Fertilizer", new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 114, "Poultry", 6, "Dressed Duck", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 115, "Poultry", 6, "Smoked Chicken", new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 116, "Poultry", 6, "Chicken Sausages", new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 117, "Poultry", 6, "Chicken Burgers", new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 118, "Poultry", 6, "Chicken Nuggets", new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 119, "Poultry", 6, "Frozen Chicken", new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 120, "Poultry", 6, "Feather Meal", new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 121, "Aquaculture", 7, "Tilapia", new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 122, "Aquaculture", 7, "Catfish", new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 123, "Aquaculture", 7, "Trout", new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 124, "Aquaculture", 7, "Fresh Prawns", new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 125, "Aquaculture", 7, "Shrimp", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 126, "Aquaculture", 7, "Crayfish", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 127, "Aquaculture", 7, "Fish Fillets", new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 128, "Aquaculture", 7, "Smoked Fish", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 129, "Aquaculture", 7, "Dried Fish", new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 130, "Aquaculture", 7, "Fish Oil", new DateTime(2025, 2, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 131, "Aquaculture", 7, "Fish Meal", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 132, "Aquaculture", 7, "Fish Sauce", new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 133, "Aquaculture", 7, "Aquarium Fish", new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 134, "Aquaculture", 7, "Ornamental Koi", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 135, "Aquaculture", 7, "Freshwater Mussels", new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 136, "Aquaculture", 7, "Live Fish Feed", new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 137, "Aquaculture", 7, "Seaweed", new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 138, "Aquaculture", 7, "Fish Roe", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 139, "Aquaculture", 7, "Fish Fertilizer", new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 140, "Aquaculture", 7, "Aquaponic Lettuce", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 141, "Fiber", 8, "White Alpaca Wool", new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 142, "Fiber", 8, "Black Alpaca Wool", new DateTime(2025, 2, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 143, "Fiber", 8, "Brown Alpaca Wool", new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 144, "Fiber", 8, "Hand-Spun Yarn", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 145, "Fiber", 8, "Wool Blankets", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 146, "Fiber", 8, "Wool Scarves", new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 147, "Fiber", 8, "Wool Socks", new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 148, "Fiber", 8, "Alpaca Rugs", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 149, "Fiber", 8, "Alpaca Hats", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 150, "Fiber", 8, "Felt Sheets", new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 151, "Fiber", 8, "Wool Gloves", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 152, "Fiber", 8, "Baby Alpaca Fiber", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 153, "Fiber", 8, "Dyed Wool", new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 154, "Fiber", 8, "Wool Stuffed Toys", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 155, "Fiber", 8, "Alpaca Wool Sweaters", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 156, "Fiber", 8, "Alpaca Manure", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 157, "Fiber", 8, "Alpaca Breeding Stock", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 158, "Fiber", 8, "Wool Throws", new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 159, "Fiber", 8, "Wool Vests", new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 160, "Fiber", 8, "Wool Art Supplies", new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 161, "Vegetables", 9, "Tomatoes", new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 162, "Vegetables", 9, "Cucumbers", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 163, "Vegetables", 9, "Lettuce", new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 164, "Vegetables", 9, "Carrots", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 165, "Vegetables", 9, "Cabbage", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 166, "Vegetables", 9, "Zucchini", new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 167, "Vegetables", 9, "Green Beans", new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 168, "Vegetables", 9, "Peas", new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 169, "Vegetables", 9, "Corn", new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 170, "Vegetables", 9, "Sweet Potatoes", new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 171, "Vegetables", 9, "Spinach", new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 172, "Vegetables", 9, "Bell Peppers", new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 173, "Vegetables", 9, "Chili Peppers", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 174, "Vegetables", 9, "Butternut Squash", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 175, "Vegetables", 9, "Pumpkin", new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 176, "Vegetables", 9, "Eggplant", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 177, "Vegetables", 9, "Artichokes", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 178, "Vegetables", 9, "Garlic", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 179, "Vegetables", 9, "Ginger", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 180, "Vegetables", 9, "Leeks", new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 181, "Herbs & Honey", 10, "Wildflower Honey", new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 182, "Herbs & Honey", 10, "Karoo Fynbos Honey", new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 183, "Herbs & Honey", 10, "Beeswax", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 184, "Herbs & Honey", 10, "Propolis", new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 185, "Herbs & Honey", 10, "Royal Jelly", new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 186, "Herbs & Honey", 10, "Honeycomb", new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 187, "Herbs & Honey", 10, "Lavender", new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 188, "Herbs & Honey", 10, "Rosemary", new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 189, "Herbs & Honey", 10, "Thyme", new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 190, "Herbs & Honey", 10, "Oregano", new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 191, "Herbs & Honey", 10, "Mint", new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 192, "Herbs & Honey", 10, "Sage", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 193, "Herbs & Honey", 10, "Basil", new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 194, "Herbs & Honey", 10, "Herbal Tea Mix", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 195, "Herbs & Honey", 10, "Essential Oils", new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 196, "Herbs & Honey", 10, "Dried Herbs", new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 197, "Herbs & Honey", 10, "Herbal Soap", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 198, "Herbs & Honey", 10, "Honey Lip Balm", new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 199, "Herbs & Honey", 10, "Beeswax Candles", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 200, "Herbs & Honey", 10, "Pollen Capsules", new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Farms",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
