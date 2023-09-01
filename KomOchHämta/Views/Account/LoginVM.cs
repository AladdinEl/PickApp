using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KomOchHämta.Views.Account
{
	public class LoginVM
	{
		[Required]
		[Display(Name = "Användarnamn")]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Lösenord")]
		public string Password { get; set; }
	}
}
