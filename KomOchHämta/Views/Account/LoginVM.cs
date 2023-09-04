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
		[StringLength(20, MinimumLength = 2, ErrorMessage = "Namnet måste vara mellan 2-20 tecken.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lösenord saknas!")]
		[DataType(DataType.Password)]
		[Display(Name = "Lösenord")]
		public string Password { get; set; }
	}
}


