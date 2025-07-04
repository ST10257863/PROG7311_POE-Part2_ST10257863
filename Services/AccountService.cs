﻿using Microsoft.AspNetCore.Identity;
using PROG7311_POE_Part2_ST10257863.Data;
using PROG7311_POE_Part2_ST10257863.Models;
using PROG7311_POE_Part2_ST10257863.Services.Interfaces;

namespace PROG7311_POE_Part2_ST10257863.Services
{
	/// <summary>
	/// Provides services for account-related operations such as login, logout, and user creation.
	/// </summary>
	public class AccountService : IAccountService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="AccountService"/> class.
		/// </summary>
		/// <param name="userManager">The user manager for handling user-related operations.</param>
		/// <param name="signInManager">The sign-in manager for handling authentication.</param>
		/// <param name="roleManager">The role manager for handling role-related operations.</param>
		/// <param name="context">The database context.</param>
		public AccountService(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager,
			ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_context = context;
		}

		/// <summary>
		/// Attempts to log in a user with the provided credentials.
		/// </summary>
		/// <param name="model">The login view model containing user credentials.</param>
		/// <returns>A <see cref="SignInResult"/> indicating the result of the login attempt.</returns>
		public async Task<SignInResult> LoginAsync(LoginViewModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				return SignInResult.Failed;
			}

			return await _signInManager.PasswordSignInAsync(
				user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
		}

		/// <summary>
		/// Logs out the current user.
		/// </summary>
		public async Task LogoutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		/// <summary>
		/// Adds a new farmer user to the system.
		/// </summary>
		/// <param name="model">The view model containing the new farmer's details.</param>
		/// <returns>An <see cref="IdentityResult"/> indicating the result of the operation.</returns>
		public async Task<IdentityResult> AddFarmerAsync(AddFarmerViewModel model)
		{
			var existingUser = await _userManager.FindByEmailAsync(model.Email);
			if (existingUser != null)
			{
				return IdentityResult.Failed(new IdentityError { Description = "Email is already registered." });
			}

			var user = new ApplicationUser
			{
				UserName = model.Email,
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				UserType = ApplicationUser.UserTypeEnum.Farmer
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				if (!await _roleManager.RoleExistsAsync("Farmer"))
				{
					await _roleManager.CreateAsync(new IdentityRole("Farmer"));
				}

				await _userManager.AddToRoleAsync(user, "Farmer");

				var farmer = new Farmer
				{
					UserId = user.Id
				};
				_context.Farmers.Add(farmer);
				await _context.SaveChangesAsync();
			}

			return result;
		}

        /// <summary>
        /// Registers a new employee user in the system.
        /// </summary>
        /// <param name="model">The RegisterViewModel containing the new employee's registration details.</param>
        /// <returns>
        /// An IdentityResult object indicating the outcome of the registration process.
        /// If successful, the result will indicate success. If unsuccessful, it will contain error information.
        /// </returns>
        /// <remarks>
        /// This method performs the following steps:
        /// 1. Checks if the email is already registered.
        /// 2. Creates a new ApplicationUser with the provided details.
        /// 3. Attempts to create the user in the system.
        /// 4. If successful, ensures the "Employee" role exists and assigns it to the user.
        /// 5. Creates and saves a new Employee entity associated with the user.
        /// </remarks>
        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email is already registered." });
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserType = ApplicationUser.UserTypeEnum.Employee
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("Employee"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Employee"));
                }

                await _userManager.AddToRoleAsync(user, "Employee");

                var employee = new Employee
                {
                    UserId = user.Id
                };
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}