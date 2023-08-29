using System.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KomOchHämta.Models
{
	public class ApplicationContext: IdentityDbContext<ApplicationUser, IdentityRole, string>
	{
		
			public ApplicationContext(DbContextOptions<ApplicationContext> options) :

			base(options)

			{
				
			}

		public DbSet<Product> Products { get; set; }

	

		protected override void OnModelCreating(ModelBuilder modelBuilder)

		{

			base.OnModelCreating(modelBuilder);









			// Specificerar data som en specific tabell ska för-populeras med

			modelBuilder.Entity<Product>().HasData(

			  new Product { Id = 1, ProductName = "Lampa", Image = "Bild1", Description = "Dyr", Created = DateTime.Now },
			  new Product { Id = 2, ProductName = "Soffa", Image = "Bild2", Description = "Billig", Created = DateTime.Now },
			  new Product { Id = 3, ProductName = "Stol", Image = "Bild3", Description = "Rea", Created = DateTime.Now }
			  );
		}


	}
}
