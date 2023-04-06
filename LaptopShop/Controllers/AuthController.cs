using Microsoft.AspNetCore.Mvc;

namespace LaptopShop.Controllers
{
	public class AuthController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
