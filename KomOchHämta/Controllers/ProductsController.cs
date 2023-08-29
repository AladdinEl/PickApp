using KomOchHämta.Models;
using Microsoft.AspNetCore.Mvc;

namespace KomOchHämta.Controllers
{
	public class ProductsController : Controller
	{

        DataService dataService;

        public ProductsController(DataService dataService) // Injicera en DataService
        {
            this.dataService = dataService;
        }

        [HttpGet("")]
		public IActionResult Index()
		{
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Members));
            }
			var products = dataService.GetAllProducts();
            return View(products);
		}

        [HttpPost("")]
        public IActionResult Index(string search)
        {
            var products = dataService.SearchProducts(search);
            return View(products);
        }

		[HttpGet("members")]
		public IActionResult Members()
		{
            var products = dataService.GetAllProductsMember();
            return View(products);
        }

        [HttpPost("members")]
        public IActionResult Members(string search)
        {
            var products = dataService.SearchProductsMember(search);
            return View(products);
        }
    }
}
