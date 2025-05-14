public interface IDatabaseManagementService
{
	Task ResetDatabaseAsync();
	Task SeedRolesAndTestUsersAsync();
}