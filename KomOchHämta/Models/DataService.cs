using KomOchHämta.Views.Products;

namespace KomOchHämta.Models
{
    public class DataService
    {

       

        //// "Fejk-databas"
        List<Product> products = new List<Product>
        {
            new Product { Id = 56, ProductName = "Lampa", Image = "Bild1", Description ="Dyr", Created=DateTime.Now },
            new Product { Id = 27, ProductName = "Soffa", Image = "Bild2", Description ="Billig", Created=DateTime.Now},
            new Product { Id = 11, ProductName = "Stol", Image = "Bild3", Description ="Rea", Created=DateTime.Now},
        };


        public IndexVM[] GetAllProducts()
        {
            return products
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
            return products
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
                return products
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
