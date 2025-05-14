using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Product
	{
		[Key]
		public int Id
		{
			get; set;
		}

		[Required(ErrorMessage = "Product name is required.")]
		[StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
		[Display(Name = "Product Name")]
		public string Name
		{
			get; set;
		}

		[Required(ErrorMessage = "Category is required.")]
		[Display(Name = "Category")]
		public int CategoryId
		{
			get; set;
		}

		[ForeignKey("CategoryId")]
		public Category? Category
		{
			get; set;
		}

		[Required(ErrorMessage = "Production date is required.")]
		[DataType(DataType.Date)]
		[Display(Name = "Production Date")]
		public DateTime ProductionDate
		{
			get; set;
		}

		[Required(ErrorMessage = "Farmer is required.")]
		[Display(Name = "Farmer")]
		public int FarmerId
		{
			get; set;
		}

		[ForeignKey("FarmerId")]
		public Farmer? Farmer
		{
			get; set;
		}
	}
}