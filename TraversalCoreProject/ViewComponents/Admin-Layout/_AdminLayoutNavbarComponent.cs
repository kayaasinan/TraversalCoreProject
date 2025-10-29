using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Admin_Layout
{
    public class _AdminLayoutNavbarComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminLayoutNavbarComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.fullName = values.Name + " " + values.SurName;
            ViewBag.image = values.ImageUrl;
            return View();
        }
    }
}
