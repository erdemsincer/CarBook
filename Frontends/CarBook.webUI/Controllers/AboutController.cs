﻿using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımızda";
            ViewBag.v2 = "Vizyonumuz & Misyonumuz";

            return View();
        }
    }
}
