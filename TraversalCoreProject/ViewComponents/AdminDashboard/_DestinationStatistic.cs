using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _DestinationStatistic : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _DestinationStatistic(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetList().Take(4).ToList();
            return View(values);
        }
    }
}
