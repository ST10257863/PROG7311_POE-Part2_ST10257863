using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_Part2_ST10257863.Models
{
	public class LoginViewModel
	{
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

		[Display(Name = "Remember Me")]
		public bool RememberMe
		{
			get; set;
		}
	}
}