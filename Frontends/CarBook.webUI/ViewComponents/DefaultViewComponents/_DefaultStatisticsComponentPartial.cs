using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { 
        return View();
        }
    }
}
