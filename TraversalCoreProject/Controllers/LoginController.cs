using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using System.Threading.Tasks;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class LoginController(UserManager<AppUser> _userManager,
                                    SignInManager<AppUser> _signInManager) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser()
            {
                Name = model.Name,
                SurName = model.SurName,
                Email = model.Mail,
                UserName = model.UserName
            };
            if (model.Password == model.ComfirmPassword)
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) return RedirectToAction("SignIn");
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.userName);
            if (user == null)
            {
                ModelState.AddModelError("", "Bu e-mail sistemde kayıtlı değil");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email veya şifre hatalı");
                return View(model);
            }
            return RedirectToAction("Index", "Profile", new { area = "Member" });
        }
    }
}
