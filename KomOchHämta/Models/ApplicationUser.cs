using Microsoft.AspNetCore.Identity;

namespace KomOchHämta.Models
{
	public class ApplicationUser:IdentityUser
	{
        public List<Product> Products { get; set; } 
    }
}
