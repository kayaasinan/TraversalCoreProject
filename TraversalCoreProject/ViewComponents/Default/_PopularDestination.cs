using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _PopularDestination:ViewComponent
    {
        DestinationManager destinationManager=new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values=destinationManager.TGetList();
            return View(values);
        }
    }
}
