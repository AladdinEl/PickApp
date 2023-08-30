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


        //// "Fejk-databas"
        //List<Product> products = new List<Product>
        //{
        //    new Product { Id = 56, ProductName = "Lampa", Image = "Bild1", Description ="Dyr", Created=DateTime.Now },
        //    new Product { Id = 27, ProductName = "Soffa", Image = "Bild2", Description ="Billig", Created=DateTime.Now},
        //    new Product { Id = 11, ProductName = "Stol", Image = "Bild3", Description ="Rea", Created=DateTime.Now},
        //};

        public DataService(ApplicationContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor)
        {
            this.context = context;
            this.userManager = userManager;
            this.userID = userManager.GetUserId(accessor.HttpContext.User);


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
                    Image = o.Image
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
                })
                .SingleOrDefault();
                    
        }
        internal void Reserve(DetailsVM details/*, int userId*/)
        {              
            var model = context.Products.Find(details.Id);
            if (model != null /*&& !model.Reserved*/)
            {
                model.Reserved = !model.Reserved;
                //model.UserId = userId;
                context.SaveChanges();
            }
        }

        public void AddProduct(CreateNewVM newProduct)
        {
            //var userID = userManager.GetUserId(userID);

            context.Products.Add(new Product
            {
                ProductName = newProduct.ProductName,
                Description = newProduct.Description,
                //Image = newProduct.Image,                            
                Message = newProduct.Message,
                Location = newProduct.Location,
                UserId = userID
            });
            context.SaveChanges();
        }

    }
}
