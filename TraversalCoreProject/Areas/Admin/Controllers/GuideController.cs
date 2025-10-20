using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(GuideDto guideDto)
        {
            if (!ModelState.IsValid) return View(guideDto);

            _guideService.TAdd(guideDto);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        public IActionResult DeleteGuide(int id)
        {
            var values = _guideService.TGetById(id);
            if (values == null) return NotFound();
            _guideService.TDelete(values);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGuide(GuideDto guideDto)
        {
            if (!ModelState.IsValid) return View(guideDto);

            _guideService.TUpdate(guideDto);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        public IActionResult ChangeStatus(int id)
        {
            _guideService.TChangeStatus(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
