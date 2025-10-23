using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactUsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactUsDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            _contactUsService.TAdd(dto);
           return RedirectToAction("Index");
        }
    }
}
