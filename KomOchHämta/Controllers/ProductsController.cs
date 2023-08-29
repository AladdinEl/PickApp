using Microsoft.AspNetCore.Mvc;

namespace KomOchHämta.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
