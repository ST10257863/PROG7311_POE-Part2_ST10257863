using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Category
	{
		[Key]
		public int Id
		{
			get; set;
		}

		[Required(ErrorMessage = "Category name is required.")]
		[StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
		[Display(Name = "Category Name")]
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