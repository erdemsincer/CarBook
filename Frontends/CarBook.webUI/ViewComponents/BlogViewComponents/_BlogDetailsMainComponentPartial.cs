using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
