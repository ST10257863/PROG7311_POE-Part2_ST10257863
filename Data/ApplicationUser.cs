using Microsoft.AspNetCore.Identity;
using PROG7311_POE_Part2_ST10257863.Data;

public class ApplicationUser : IdentityUser
{
	public enum UserTypeEnum
	{
		Customer,
		Farmer,
		Employee
	}

	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;

	// Indicates the current type/status of the user
	public UserTypeEnum UserType { get; set; } = UserTypeEnum.Customer;


	public Customer CustomerProfile
	{
		get; set;
	}

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
