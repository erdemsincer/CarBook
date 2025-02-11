using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {
            var data = TempData["bookpickdate"];
            var data2 = TempData["locationId"];
            ViewBag.bookpickdate = data;
            ViewBag.locationId = data2;
            return View();
        }
    }
}
