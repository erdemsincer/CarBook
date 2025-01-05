using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.ViewComponents.CommentViewComponents
{
    public class _AddCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
