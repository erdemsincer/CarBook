using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.ViewComponents.CarDetailViewComponent
{
    public class _CarDetailTabPaneComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
