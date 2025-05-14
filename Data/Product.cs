using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Product
	{

		public int Id
		{
			get; set;
		}

		[Required(ErrorMessage = "Product name is required.")]
		[StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
		public string Name
		{
			get; set;
		}

		// Foreign key property
		[Required(ErrorMessage = "Category is required.")]
		public int CategoryId
		{
			get; set;
		}

		// Navigation property
		public Category? Category
		{
			get; set;
		}

		[Required(ErrorMessage = "Production date is required.")]
		[DataType(DataType.Date)]
		public DateTime ProductionDate
		{
			get; set;
		}

		[Required(ErrorMessage = "Farmer is required.")]
		public int FarmerId
		{
			get; set;
		}

		// Navigation property
		public Farmer? Farmer
		{
			get; set;
		}
	}
}