using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [AllowAnonymous]
    [Area("Member")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(IReservationService reservationService, IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
            _userManager = userManager;
        }

        public IActionResult MyPastReservations()
        {
            return View();
        }
        public IActionResult MyCurrentReservation()
        {
            return View();
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var approvalList = _reservationService.GetAllApprovalReservation(values.Id);
            return View(approvalList);
        }
        public IActionResult NewReservation()
        {
            List<SelectListItem> list = (from x in _destinationService.TGetList()
                                         select new SelectListItem
                                         {
                                             Text = x.City,
                                             Value = x.DestinationId.ToString()
                                         }).ToList();
            ViewBag.List = list;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation reservation)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.AppUserId = user.Id;
            //reservation.Status = "Onay Bekliyor";
            _reservationService.TAdd(reservation);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}

