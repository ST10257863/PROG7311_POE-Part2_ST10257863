using PROG7311_POE_Part2_ST10257863.Models;
using Microsoft.AspNetCore.Identity;

namespace PROG7311_POE_Part2_ST10257863.Services.Interfaces
{
	public interface IAccountService
	{
		Task<SignInResult> LoginAsync(LoginViewModel model);
		Task LogoutAsync();
		Task<IdentityResult> AddFarmerAsync(AddFarmerViewModel model);
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);

    }
}