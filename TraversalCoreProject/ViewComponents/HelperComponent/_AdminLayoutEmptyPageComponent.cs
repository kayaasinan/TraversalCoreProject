using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.HelperComponent
{
    public class _AdminLayoutEmptyPageComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var emptyPageMessage = "Görüntülenecek veri/içerik bulunamadı..!";
            return View("Default", emptyPageMessage);
        }
    }
}
