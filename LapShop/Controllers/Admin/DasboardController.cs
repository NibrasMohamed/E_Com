using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers.Admin
{
    public class DasboardController : Controller
    {
        public IActionResult Index()
        {
            return View("Admin/Dashboard");
        }
    }
}
