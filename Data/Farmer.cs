using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Farmer
	{
		[Key]
		public int Id
		{
			get; set;
		}

		[Required(ErrorMessage = "User ID is required.")]
		public string UserId
		{
			get; set;
		}

		[ForeignKey("UserId")]
		public ApplicationUser User
		{
			get; set;
		}

		[Display(Name = "Products")]
		public ICollection<Product> Products
		{
			get; set;
		}
	}
}