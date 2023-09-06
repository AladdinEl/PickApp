
using KomOchHämta.Views.Account;
using Microsoft.AspNetCore.Identity;

namespace KomOchHämta.Models
{
	public class AccountService
	{


		UserManager<ApplicationUser> userManager;

		SignInManager<ApplicationUser> signInManager;

		RoleManager<IdentityRole> roleManager;



		public AccountService(

	  UserManager<ApplicationUser> userManager,

	  SignInManager<ApplicationUser> signInManager,

	  RoleManager<IdentityRole> roleManager)

		{

			this.userManager = userManager;

			this.signInManager = signInManager;

			this.roleManager = roleManager;

		}

		public async Task<string> TryRegisterAsync(RegisterVM viewModel)
		{
			var user = new ApplicationUser
			{
				UserName = viewModel.Username,
			};
			IdentityResult result = await
				userManager.CreateAsync(user, viewModel.Password);



			bool wasCreatedUser = result.Succeeded;
			if (wasCreatedUser)
			{
				return null;
			}
			else
				return result.Errors
					.Select(o => o.Description)
					.First();
		}

		public async Task<string> TryLoginAsync(LoginVM viewModel)
		{
			SignInResult result = await signInManager.PasswordSignInAsync(
				viewModel.Username,
				viewModel.Password,
				isPersistent: false,
				lockoutOnFailure: false
				);



			bool wasUserSignedin = result.Succeeded;



			if (wasUserSignedin)
			{
				return null;
			}
			else
				return "Failed to login";
		}

		public async Task TryLogOutAsync()
		{
			await signInManager.SignOutAsync();
		}
	}
}
