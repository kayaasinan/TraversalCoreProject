using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values=_contactUsService.TGetListContactUsByTrue();
            return View(values);
        }
        public IActionResult ChangeStatus(int id)
        {
            _contactUsService.TMessageToggleStatus(id);
            return RedirectToAction("Index", "ContactUs", new { area = "Admin" });
        }
    }
}
