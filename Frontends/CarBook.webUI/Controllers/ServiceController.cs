using CarBook.Dto.ServiceDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.webUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index() { 

            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetlerimiz";
           
            return View(); 
        }
    }
}
