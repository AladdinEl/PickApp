using KomOchHämta.Models;
using KomOchHämta.Views.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KomOchHämta.Controllers
{
    [Authorize]
	public class ProductsController : Controller
	{

        DataService dataService;

        public ProductsController(DataService dataService) // Injicera en DataService
        {
            this.dataService = dataService;
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPost("SearchProductsMember")]
        public IActionResult SearchProductsMember(string search)
        {
            var products = dataService.SearchProductsMember(search);
            return PartialView("_ProductList", products);
        }


        [AllowAnonymous]
        [HttpGet("/Details/{id}")]
        public IActionResult Details(int id)
        {
            var model = dataService.GetById(id);
            return View(model);
        }

        [HttpPost("/Details/{id}")]
        public IActionResult Details(DetailsVM details, string reservedBy)
        {
            dataService.Reserve(details, reservedBy);
            return RedirectToAction(nameof(Details));
        }

        [HttpGet("/CreateNew")]
        public IActionResult CreateNew()
        { 
            return View();
        }

        [HttpPost("/CreateNew")]
        public IActionResult CreateNew(CreateNewVM newProduct) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            dataService.AddProduct(newProduct);
            return RedirectToAction(nameof(Members));

        }

        [HttpGet("/Edit/{id}")]
        public IActionResult Edit(int id)
        {
			var model = dataService.GetEditProduct(id);
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (model.UserId != userId) // Jämför användar-ID för produkten med inloggad användare
			{
				return Forbid(); // Användaren har inte tillstånd att redigera denna produkt
			}
			return View(model);
		}


        [HttpPost("/Edit/{id}")]
        public IActionResult Edit(EditVM editProduct)
        {
			if (!ModelState.IsValid)
            {
				return View(nameof(Edit));
			}
			dataService.EditProduct(editProduct);
			return RedirectToAction(nameof(Members));
		}

        [HttpGet("/Delete/{id}")]
        public IActionResult Delete(int id) 
        {
            dataService.Delete(id);
            return RedirectToAction(nameof(Members));
        }


    }
}
