using BusinessLayer.Abstract;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }
        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetById(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser(AppUserDto appUserDto)
        {
            _appUserService.TUpdate(appUserDto);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        public IActionResult CommentUser(int id)
        {
            var values = _appUserService.TGetList();
            return View();
        }
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.TGetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
