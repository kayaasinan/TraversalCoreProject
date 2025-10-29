using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IFeatureService _featureService;

        public BannerController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IActionResult Index()
        {
            var values = _featureService.TGetList();
            return View(values);
        }
    }
}
