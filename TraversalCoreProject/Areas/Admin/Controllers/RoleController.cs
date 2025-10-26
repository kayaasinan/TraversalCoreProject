using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet("AddRole")]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _roleManager.CreateAsync(new AppRole { Name = model.Name.Trim() });

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }
        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = await _roleManager.FindByIdAsync(id.ToString());
            if (value != null)
                await _roleManager.DeleteAsync(value);

            return RedirectToAction("Index");
        }
        [HttpGet("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var value = await _roleManager.FindByIdAsync(id.ToString());
            if (value == null)
                return NotFound();

            var model = new UpdateRoleViewModel
            {
                Id = value.Id,
                Name = value.Name
            };

            return View(model);
        }
        [HttpPost("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var role = await _roleManager.FindByIdAsync(model.Id.ToString());
            if (role == null)
            {
                ModelState.AddModelError("", "Rol bulunamadı.");
                return View(model);
            }
            role.Name = model.Name.Trim();

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            return View(model);
        }
        [HttpGet("UserList")]
        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet("AssingRole/{id}")]
        public async Task<IActionResult> AssingRole(int id)
        {
            var users = await _userManager.FindByIdAsync(id.ToString());
            TempData["userId"] = users.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(users);
            var modelAssingn = new List<RoleAssingViewModel>();
            foreach (var item in roles)
            {
                var model = new RoleAssingViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Exist = userRoles.Contains(item.Name);
                modelAssingn.Add(model);
            }
            return View(modelAssingn);
        }
        [HttpPost("AssingRole/{id}")]
        public async Task<IActionResult> AssignRole(List<RoleAssingViewModel> model)
        {
            var userid = (int)TempData["userId"];
            var users = await _userManager.FindByIdAsync(userid.ToString());
            foreach (var item in model)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(users, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(users, item.Name);
                }
            }
            return RedirectToAction("UserList");
        }
    }
}
