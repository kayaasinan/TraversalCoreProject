using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.MemberDashboard
{
    public class _MemberStatistics : ViewComponent
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly Context _context;

        public _MemberStatistics(IReservationService reservationService, UserManager<AppUser> userManager, Context context, IAppUserService appUserService)
        {
            _reservationService = reservationService;
            _userManager = userManager;
            _context = context;
            _appUserService = appUserService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = _reservationService.TGetListWithReservationByAccepted(values.Id).Count();
            ViewBag.v2 = _reservationService.TGetListWithReservationByPrevious(values.Id).Count();
            ViewBag.v3 = _reservationService.TGetListWithReservationByWaitApproval(values.Id).Count();
            ViewBag.v4 = _context.Guides.Count();
            ViewBag.v5 = _appUserService.TGetList().Count();
            ViewBag.v6 =_context.Destinations.Count();
            return View();
        }
    }
}
