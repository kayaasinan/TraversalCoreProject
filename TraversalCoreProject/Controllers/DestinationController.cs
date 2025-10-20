using BusinessLayer.Abstract;
using DTOLayer.DTOs.DestinationDTOs;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class DestinationController : Controller
    {

        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
                _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i=id;
            var values=_destinationService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(DestinationDto d)
        {
            return View();
        }
    }
}

