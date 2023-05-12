using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVCNew.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
