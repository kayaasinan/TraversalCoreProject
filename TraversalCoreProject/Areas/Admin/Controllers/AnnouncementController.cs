using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.TGetList();
            return View(values);
        }
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementDto announcement)
        {
            if (!ModelState.IsValid) return View(announcement);

            _announcementService.TAdd(announcement);
            return RedirectToAction("Index", "Announcement", new { area = "Admin" });
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.TGetById(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Index", "Announcement", new { area = "Admin" });
        }
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _announcementService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementDto announcement)
        {
            if (!ModelState.IsValid) return View(announcement);
            _announcementService.TUpdate(announcement);
            return RedirectToAction("Index", "Announcement", new { area = "Admin" });
        }
    }
}
