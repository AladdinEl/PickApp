using System.ComponentModel.DataAnnotations;

namespace KomOchHämta.Views.Account
{
	public class RegisterVM
	{
		[Required]
		public string Username { get; set; }

		[Required]
		[Display(Name ="Lösenord")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Upprepa lösenord")]
		[Compare(nameof(Password))]
		public string PasswordRepeat { get; set; }

		[Required]
		[Display(Name ="Förnamn")]
        public string FirstName { get; set; }

		[Required]
		[Display(Name = "Efternamn")]
		public string LastName { get; set; }


		[Required]
		[Display(Name = "E-mail")]
		[EmailAddress(ErrorMessage = "Ogiltig e-mail adress")]
		public string Email { get; set; }
    }
}
