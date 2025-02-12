using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1= "Araç Kiralama";
            ViewBag.v2= "Araç Rezervasyon Formu";
            return View();
        }
    }
}
