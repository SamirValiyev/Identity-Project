using IdentityProject.Enums;
using IdentityProject.Models;
using IdentityProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
                    EmailConfirmed=true

                };
                var identityResult= await _userManager.CreateAsync(appUser,model.Password);
                if (identityResult.Succeeded)
                {
                    
                    //await _roleManager.CreateAsync(new AppRole
                    //{
                    //    Name = "Admin",
                    //    CreatedDate = DateTime.Now
                    //});
                    await _userManager.AddToRoleAsync(appUser, "Admin");
                    return RedirectToAction("Index", "Home");
                }
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

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVM model)
        {
            if(!ModelState.IsValid) return View(model);
            else
            {
                var signInResult=await _signInManager.PasswordSignInAsync(model.UserName, model.Password,false,true);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                    // signin ugurlu
                }
                else if (signInResult.IsLockedOut)
                {
                    //signin (hesab kilitlendi)
                }
                else if (signInResult.IsNotAllowed)
                {
                    // email ve ya nomre dogrulamasi(tesdiqlenmemesi)
                }
            }
            return View(model);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult GetUserDetail()
        {
            var user = User.Identity.Name;
            var role=User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.Role);

            return View();
        }
    }
}
