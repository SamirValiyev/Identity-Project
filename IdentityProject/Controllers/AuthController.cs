using IdentityProject.Enums;
using IdentityProject.Models;
using IdentityProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]   
        public IActionResult Create()
        {
            var model = new UserCreateVM
            {
                Genders=Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(g=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value=((int)g).ToString(),
                    Text=g.ToString()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateVM model)
        {
            if (!ModelState.IsValid) return View(model);
            else
            {
                AppUser appUser = new AppUser()
                {
                    Email = model.Email,
                    UserName = model.Username,
                    Gender = model.Gender,

                };
                var identityResult= await _userManager.CreateAsync(appUser,model.Password);
                if (identityResult.Succeeded) return RedirectToAction("Index","Home");
                else
                {
                    foreach(var error in identityResult.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
