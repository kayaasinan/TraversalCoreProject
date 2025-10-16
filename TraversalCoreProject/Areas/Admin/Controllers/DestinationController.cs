using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.TAdd(destination);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteDestination(int id)
        {
            var values=_destinationService.TGetById(id);
            _destinationService.TDelete(values);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UpdateDestination(int id)
        {
            var values=_destinationService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination t)
        {
             _destinationService.TUpdate(t);
            return RedirectToAction(nameof(Index));
        }
    }
}
