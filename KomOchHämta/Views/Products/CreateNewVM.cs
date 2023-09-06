using System.ComponentModel.DataAnnotations;

namespace KomOchHämta.Views.Products
{
    public class CreateNewVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Produktnamn")]
        [StringLength(50, MinimumLength = 2)]
        public string ProductName { get; set; }

        [Display(Name = "Bild")]
        public IFormFile? Image { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        public DateTime Created { get; set; }

        public bool Reserved { get; set; }
        //public string? UserId { get; set; }

        [Required]
        [Display(Name = "Plats")]
        public string? Location { get; set; }

        [Display(Name = "Meddelande till upphämtare")]
        public string? Message { get; set; }
    }
}
