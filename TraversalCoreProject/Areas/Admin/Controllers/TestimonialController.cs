using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var values = _testimonialService.TGetList();
            return View(values);
        }
        public IActionResult ChangeStatus(int id)
        {
            _testimonialService.TChangeStatus(id);
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        }
    }
}
