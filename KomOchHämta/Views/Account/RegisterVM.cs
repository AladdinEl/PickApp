using System.ComponentModel.DataAnnotations;

namespace KomOchHämta.Views.Account
{
	public class RegisterVM
	{
		[Required]
		[Display(Name = "Användarnamn")]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "Användarnamnet måste vara mellan 2 och 20 bokstäver")]
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
		[Display(Name = "E-mail")]
		[EmailAddress(ErrorMessage = "Ogiltig e-mail adress")]
		public string Email { get; set; }
    }
}
