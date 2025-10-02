using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProject.Areas.Member.Models;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class ProfileController(UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new UserEditViewModel();
            model.name = user.Name;
            model.surname= user.SurName;
            model.phoneNumber = user.PhoneNumber;
            model.mail = user.Email;
            return View(model);
        }
    }
}
