using Microsoft.AspNetCore.Identity;
using PROG7311_POE_Part2_ST10257863.Data;

public class ApplicationUser : IdentityUser
{
	public enum UserTypeEnum
	{
		Farmer,
		Employee
	}

	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;

	// Navigation property for Employee profile
	public Employee EmployeeProfile
	{
		get; set;
	}

	// Navigation property for Farmer profile
	public Farmer FarmerProfile
	{
		get; set;
	}
}
