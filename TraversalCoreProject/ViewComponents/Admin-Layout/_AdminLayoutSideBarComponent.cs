using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Admin_Layout
{
    public class _AdminLayoutSideBarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
