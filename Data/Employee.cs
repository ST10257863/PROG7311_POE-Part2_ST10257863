using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class Employee
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
	}
}