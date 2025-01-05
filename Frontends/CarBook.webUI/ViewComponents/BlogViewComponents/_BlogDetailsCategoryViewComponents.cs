using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryViewComponents:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
