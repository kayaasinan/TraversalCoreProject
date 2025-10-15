using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _SubAboutPartial:ViewComponent
    {
        private readonly ISubAboutService _subAboutService;

        public _SubAboutPartial(ISubAboutService subAboutService)
        {
            _subAboutService = subAboutService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _subAboutService.TGetList();
            return View(values);
        }
    }
}
