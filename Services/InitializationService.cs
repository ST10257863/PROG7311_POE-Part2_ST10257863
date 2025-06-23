using PROG7311_POE_Part2_ST10257863.Data;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

public class InitializationService : IInitializationService
{
    private readonly ApplicationDbContext _context;
    private readonly IDatabaseManagementService _databaseManagementService;

    /// <summary>
    /// Initializes a new instance of the <see cref="InitializationService"/> class.
    /// </summary>
    /// <param name="context">The application database context used for data access.</param>
    /// <param name="databaseManagementService">The service responsible for managing database operations.</param>
    public InitializationService(ApplicationDbContext context, IDatabaseManagementService databaseManagementService)
    {
        _context = context;
        _databaseManagementService = databaseManagementService;
    }

    /// <summary>
    /// Initializes the database asynchronously if it's empty.
    /// </summary>
    /// <remarks>
    /// This method checks if there are any users in the database. If the database is empty,
    /// it calls the ResetDatabaseAsync method to populate it with initial data.
    /// </remarks>
    /// <returns>
    /// A Task representing the asynchronous operation.
    /// </returns>
    public async Task InitializeAsync()
    {
        if (!_context.Users.Any())
        {
            await _databaseManagementService.ResetDatabaseAsync();
        }
    }
}