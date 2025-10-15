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

        public async Task<IActionResult> MyPastReservations()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var list = _reservationService.GetListWithReservationByPrevious(values.Id);
            return View(list);
        }
        public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var list = _reservationService.GetListWithReservationByAccepted(values.Id);
            return View(list);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var list = _reservationService.GetListWithReservationByWaitApproval(values.Id);
            return View(list);
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
            reservation.Status = ReservationStatus.OnayBekliyor;
            _reservationService.TAdd(reservation);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}

