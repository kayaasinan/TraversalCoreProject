using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _AdminGuideList : ViewComponent
    {
        private readonly IGuideService _guideService;

        public _AdminGuideList(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideService.TGetList().Take(6).ToList();
            return View(values);
        }
    }
}
