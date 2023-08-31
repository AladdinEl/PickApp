using KomOchHämta.Controllers;
using KomOchHämta.Views.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace KomOchHämta.Models
{
    public class DataService
    {

        ApplicationContext context;
        private readonly UserManager<ApplicationUser> userManager;
        string userID;
		IWebHostEnvironment webHostEnv;


		//// "Fejk-databas"
		//List<Product> products = new List<Product>
		//{
		//    new Product { Id = 56, ProductName = "Lampa", Image = "Bild1", Description ="Dyr", Created=DateTime.Now },
		//    new Product { Id = 27, ProductName = "Soffa", Image = "Bild2", Description ="Billig", Created=DateTime.Now},
		//    new Product { Id = 11, ProductName = "Stol", Image = "Bild3", Description ="Rea", Created=DateTime.Now},
		//};

		public DataService(ApplicationContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor, IWebHostEnvironment webHostEnv)
        {
            this.context = context;
            this.userManager = userManager;
            this.userID = userManager.GetUserId(accessor.HttpContext.User);
			this.webHostEnv = webHostEnv;

		}


        public IndexVM[] GetAllProducts()
        {
            return context.Products
            .OrderBy(o => o.Created)
                .Select(o => new IndexVM
                {
                    Id = o.Id,
                    ProductName = o.ProductName,
                    Image = o.Image
                })
            .ToArray();

        }
        public MembersVM[] GetAllProductsMember()
        {
            return context.Products
            .OrderBy(o => o.Created)
                .Select(o => new MembersVM
                {
                    Id = o.Id,
                    ProductName = o.ProductName,
                    Image = o.Image,
                    UserId = o.UserId
                })
            .ToArray();
        }

        public IndexVM[] SearchProducts(string search)
        {
            var product = context.Products.Where(o => o.ProductName.Contains(search));
            var result = search != null ? product : context.Products;

            return result
            .OrderBy(o => o.Created)
                .Select(o => new IndexVM
                {
                    Id = o.Id,
                    ProductName = o.ProductName,
                    Image = o.Image
                })
            .ToArray();
        }

        public MembersVM[] SearchProductsMember(string search)
        {
            var product = context.Products.Where(o => o.ProductName.Contains(search));
            var result = search != null ? product : context.Products;
            
                return result
                .OrderBy(o => o.Created)
                    .Select(o => new MembersVM
                    {
                        Id = o.Id,
                        ProductName = o.ProductName,
                        Image = o.Image
                    })
                .ToArray();
        }

        internal DetailsVM? GetById(int id)
        {
            return context.Products
                .Where(o => o.Id == id)
                .Select(o => new DetailsVM
                {
                    Id = o.Id,
                    ProductName = o.ProductName,
                    Created = o.Created,
                    Description = o.Description,
                    Image = o.Image,
                    Reserved = o.Reserved,
                    UserId = o.UserId,
                    ReservedBy = o.ReservedBy,
                })
                .SingleOrDefault();
                    
        }
        internal void Reserve(DetailsVM details, string reservedBy)
        {              
            var model = context.Products.Find(details.Id);
            if (model != null /*&& !model.Reserved*/)
            {       
                model.Reserved = !model.Reserved;
                model.ReservedBy = reservedBy;
                //model.UserId = userId;
                context.SaveChanges();
            }
        }

        public void AddProduct(CreateNewVM newProduct)
        {
			if (newProduct.Image != null)
				UploadImage(newProduct.Image);

			context.Products.Add(new Product
            {
                ProductName = newProduct.ProductName,
                Description = newProduct.Description,
				Image = $"/Images/{newProduct.Image?.FileName}",                         
				Message = newProduct.Message,
                Location = newProduct.Location,
                Created = DateTime.Now,
                UserId = userID
            });
            context.SaveChanges();
        }

		public void UploadImage(IFormFile image)
		{
			var filePath = Path.Combine(webHostEnv.WebRootPath, "Images", image.FileName);
			using var fileStream = new FileStream(filePath, FileMode.Create);
			{ image.CopyTo(fileStream); }
		}

        public EditVM? GetEditProduct(int id)
        {
			return context.Products
				.Where(o => o.Id == id)
				.Select(o => new EditVM
                {
					Id = o.Id,
					ProductName = o.ProductName,
					Description = o.Description,
					//Image = o.Image,
					Message = o.Message,
					Location = o.Location,
					Created = o.Created,
					Reserved = o.Reserved,
					UserId = o.UserId,
					ReservedBy = o.ReservedBy
				})
				.SingleOrDefault();
		}

        public void EditProduct(EditVM editProduct)
        {
			var model = context.Products.Find(editProduct.Id);
            if (editProduct.Image != null)
                UploadImage(editProduct.Image);

			if (model != null)
            {
				model.ProductName = editProduct.ProductName;
				model.Description = editProduct.Description;
				model.Message = editProduct.Message;
				model.Location = editProduct.Location;
				model.Created = DateTime.Now;
				model.UserId = userID;
                model.Image = $"/Images/{editProduct.Image?.FileName}";
				context.SaveChanges();
			}
		}

	}
}
