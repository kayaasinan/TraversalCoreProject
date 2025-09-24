using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _SubAboutPartial:ViewComponent
    {
        SubAboutManager subAboutManager=new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values= subAboutManager.TGetList();
            return View(values);
        }
    }
}
