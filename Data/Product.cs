using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Products
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

		[Required(ErrorMessage = "Category is required.")]
		[StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
		public string Category
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
		} // Foreign key property

		public Farmer? Farmer
		{
			get; set;
		} // Navigation property
	}
}