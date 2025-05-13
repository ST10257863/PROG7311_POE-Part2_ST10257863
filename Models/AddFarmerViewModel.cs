using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_Part2_ST10257863.Models
{
	public class AddFarmerViewModel
	{
		[Required]
		[Display(Name = "First Name")]
		public string FirstName
		{
			get; set;
		}

		[Required]
		[Display(Name = "Last Name")]
		public string LastName
		{
			get; set;
		}

		[Required]
		[EmailAddress]
		public string Email
		{
			get; set;
		}

		[Required]
		[DataType(DataType.Password)]
		public string Password
		{
			get; set;
		}

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Passwords do not match.")]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword
		{
			get; set;
		}
	}
}