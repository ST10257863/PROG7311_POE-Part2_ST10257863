using Microsoft.AspNetCore.Mvc;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Category
	{
		public int Id
		{
			get; set;
		}
		public string Name
		{
			get; set;
		}

		// Navigation property for related products
		public ICollection<Product> Products
		{
			get; set;
		}
	}

}
