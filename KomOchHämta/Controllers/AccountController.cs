using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KomOchHämta.Models;
using KomOchHämta.Views.Account;

namespace KomOchHämta.Controllers
{
	public class AccountController : Controller
	{
		AccountService accountService;

		public AccountController(AccountService accountService)
		{
			this.accountService = accountService;
		}

		[HttpGet("members")]
		public IActionResult Members()
		{
			return View();
		}

		[HttpGet("register")]
		public IActionResult Register()
		{
			return View();
		}



		[HttpPost("register")]

		public async Task<IActionResult> RegisterAsync(RegisterVM viewModel)
		{
			if (!ModelState.IsValid)

				return View();

			var errorMessage = await accountService.TryRegisterAsync(viewModel);

			if (errorMessage != null)

			{
				ModelState.AddModelError(string.Empty, errorMessage);

				return View();
			}

			return RedirectToAction(nameof(Login));

		}

		[HttpGet("login")]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync(LoginVM viewModel)
		{
			if (!ModelState.IsValid)
				return View();

			var errorMessage = await accountService.TryLoginAsync(viewModel);
			if (errorMessage != null)
			{
				ModelState.AddModelError(string.Empty, errorMessage);
				return View();
			}
			return RedirectToAction(nameof(Members));
		}

		[HttpGet("/logout")]
		public async Task<IActionResult> LogOutAsync()
		{
			await accountService.TryLogOutAsync();
			return RedirectToAction(nameof(Register));
		}

	}
}
