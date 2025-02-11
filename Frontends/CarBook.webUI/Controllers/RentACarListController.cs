using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
