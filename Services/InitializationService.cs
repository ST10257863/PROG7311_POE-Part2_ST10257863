using PROG7311_POE_Part2_ST10257863.Data;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

public class InitializationService : IInitializationService
{
    private readonly ApplicationDbContext _context;
    private readonly IDatabaseManagementService _databaseManagementService;

    public InitializationService(ApplicationDbContext context, IDatabaseManagementService databaseManagementService)
    {
        _context = context;
        _databaseManagementService = databaseManagementService;
    }

    public async Task InitializeAsync()
    {
        if (!_context.Users.Any())
        {
            await _databaseManagementService.ResetDatabaseAsync();
        }
    }
}