using Microsoft.AspNetCore.Identity;
using PROG7311_POE_Part2_ST10257863.Data;

public class ApplicationUser : IdentityUser
{
	public bool IsEmployee
	{
		get; set;
	}

	public Employee EmployeeProfile
	{
		get; set;
	}
	public Farmer FarmerProfile
	{
		get; set;
	}
}