using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.HelperComponent
{
    public class _MemberLayoutEmptyPageComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var emptyPageMessage = "Görüntülenecek rezervasyon bulunamadı";
            return View("Default", emptyPageMessage);
        }
    }
}
