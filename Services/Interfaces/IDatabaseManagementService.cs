namespace PROG7311_POE_Part2_ST10257863.Services.Interfaces
{
	public interface IDatabaseManagementService
	{
		Task ResetDatabaseAsync();
		Task SeedRolesAndTestUsersAsync();
	}
}