using KomOchHämta.Views.Products;

namespace KomOchHämta.Models
{
    public class DataService
    {

        ApplicationContext context;

        //// "Fejk-databas"
        //List<Product> products = new List<Product>
        //{
        //    new Product { Id = 56, ProductName = "Lampa", Image = "Bild1", Description ="Dyr", Created=DateTime.Now },
        //    new Product { Id = 27, ProductName = "Soffa", Image = "Bild2", Description ="Billig", Created=DateTime.Now},
        //    new Product { Id = 11, ProductName = "Stol", Image = "Bild3", Description ="Rea", Created=DateTime.Now},
        //};

        public DataService(ApplicationContext context)
        {
            this.context = context;
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
                    Image = o.Image
                })
                .SingleOrDefault();
                    
        }

        internal void Reserve(int id)
        {
            var model = context.Products.Find(id);
            model.Reserved = true;
            context.SaveChanges();
        }
    }
}
