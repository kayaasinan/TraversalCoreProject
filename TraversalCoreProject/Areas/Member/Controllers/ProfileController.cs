using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Member.Models;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [AllowAnonymous]
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController(UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name) ?? new AppUser();
            var model = new UserEditViewModel();
            model.name = user.Name;
            model.surname = user.SurName;
            model.phoneNumber = user.PhoneNumber ?? string.Empty;
            model.mail = user.Email;
            model.imageUrl = user.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userImages/" + imageName;
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }
                user.ImageUrl ="/userImages/" + imageName;
                
            }
            user.Name = model.name;
            user.SurName = model.surname;
           
            if (!string.IsNullOrEmpty(model.password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.password);
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.password))
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    return RedirectToAction("Index", "Profile", new { area = "Member" });
                }
            }
            return View(model);
        }
    }
}
