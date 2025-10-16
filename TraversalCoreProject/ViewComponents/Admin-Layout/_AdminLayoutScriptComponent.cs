using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Admin_Layout
{
    public class _AdminLayoutScriptComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
