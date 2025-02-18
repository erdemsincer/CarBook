using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
