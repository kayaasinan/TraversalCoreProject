using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController(UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values.Name + " " + values.SurName;
            ViewBag.images = values.ImageUrl;
            return View();
        }
        public IActionResult MemberDashboard()
        {
            return View();
        }
    }
}
