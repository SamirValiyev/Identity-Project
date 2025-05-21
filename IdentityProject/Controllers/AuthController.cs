using IdentityProject.Enums;
using IdentityProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.Controllers
{
    public class AuthController : Controller
    {
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
        public IActionResult Create(UserCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }
            return View();
        }
    }
}
