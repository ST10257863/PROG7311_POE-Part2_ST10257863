using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class ApplicationUser : IdentityUser
	{
		public enum UserTypeEnum
		{
			Farmer,
			Employee
		}

		[Required(ErrorMessage = "User type is required.")]
		public UserTypeEnum UserType
		{
			get; set;
		}

		[Required(ErrorMessage = "First name is required.")]
		[StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Last name is required.")]
		[StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; } = string.Empty;

		// Navigation property for Employee profile
		public Employee? EmployeeProfile
		{
			get; set;
		}

		// Navigation property for Farmer profile
		public Farmer? FarmerProfile
		{
			get; set;
		}
	}
}