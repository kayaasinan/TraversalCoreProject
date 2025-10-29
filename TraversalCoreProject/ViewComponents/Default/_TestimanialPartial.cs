using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _TestimanialPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _TestimanialPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetList().Take(4).ToList();
            return View(values);
        }
    }
}
