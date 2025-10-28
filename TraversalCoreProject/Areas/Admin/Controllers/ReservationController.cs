using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _reservationService.TGetAllReservationsWithDetails();
            return View(values);
        }

        [HttpPost]
        public IActionResult ChangeStatus(int id, ReservationStatus status)
        {
            _reservationService.TChangeReservationStatus(id, status);
            return RedirectToAction("Index");
        }
    }
}
