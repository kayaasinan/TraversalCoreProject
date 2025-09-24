using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _StatisticsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.d1 = c.Destinations.Count();
            ViewBag.d2 = c.Guides.Count();
            ViewBag.cumstomerCount = "217";
            ViewBag.awardCount = "32";
            return View();
        }
    }
}
