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

        public IndexVM[] SearchProducts(string search)
        {
            if (search != null)
            {
            return context.Products
            .Where(o => o.ProductName.Contains(search))
            .OrderBy(o => o.Created)
                .Select(o => new IndexVM
                {
                    Id = o.Id,
                    ProductName = o.ProductName,
                    Image = o.Image
                })
            .ToArray();
            }
            else
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
        }

        
    }
}
