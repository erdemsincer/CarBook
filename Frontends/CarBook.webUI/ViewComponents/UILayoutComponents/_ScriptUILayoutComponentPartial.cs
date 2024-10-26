using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.ViewComponents.UILayoutComponents
{
    public class _ScriptUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
