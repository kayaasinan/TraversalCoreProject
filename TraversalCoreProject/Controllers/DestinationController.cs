using BusinessLayer.Abstract;
using DTOLayer.DTOs.DestinationDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {

        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.i=id;
            ViewBag.destID=id;
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userId = values.Id;
            var value=_destinationService.TGetDestinationWithGuide(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult DestinationDetails(DestinationDto d)
        {
            return View();
        }
    }
}

