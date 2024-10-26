using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.ViewComponents.UILayoutComponents
{
    public class _MainCoverUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
