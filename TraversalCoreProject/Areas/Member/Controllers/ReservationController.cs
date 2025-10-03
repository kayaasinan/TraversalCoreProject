using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [AllowAnonymous]
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult PastReservations()
        {
            return View();
        }
        public IActionResult CurrentReservation()
        {
            return View();
        }
        public IActionResult NewReservation()
        {
            List<SelectListItem> list = (from x in destinationManager.TGetList()
                                         select new SelectListItem
                                         {
                                             Text=x.City,
                                             Value=x.DestinationId.ToString()
                                         }).ToList();
            ViewBag.List = list;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            return View();
        }
    }
}

