using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class LastDestinationController(IDestinationService _destinationService) : Controller
    {
        public IActionResult Index()
        {
            var values=_destinationService.TGetLast4Destination();
            return View(values);
        }
    }
}
