using System.ComponentModel.DataAnnotations;

namespace KomOchHämta.Views.Products
{
    public class EditVM
    {
        public int Id { get; set; }

		[Required(ErrorMessage = "Produktnamn måste anges.")]
		[Display(Name = "Produktnamn")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Måste vara 2-50 tecken.")]
		public string ProductName { get; set; }
        public IFormFile? Image { get; set; }

		[Display(Name = "Beskrivning")]
		public string Description { get; set; }

        public DateTime Created { get; set; }
        public bool Reserved { get; set; }

		//public string? UserId { get; set; }
		[Required(ErrorMessage = "Upphämtningsplats måste anges.")]
		[Display(Name = "Plats")]
		public string? Location { get; set; }

		[Display(Name = "Meddelande till upphämtare (skickas på mail)")]
		public string? Message { get; set; }

        public string? ReservedBy { get; set; }

        public string? UserId { get; set; }

	}
}
