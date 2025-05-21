using IdentityProject.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace IdentityProject.ViewModels
{
    public class UserCreateVM
    {
        [Required(ErrorMessage ="Username is Required")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage ="Please enter your Email")]
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public Gender Gender { get; set; }
        public ICollection<SelectListItem> Genders { get; set; }

    }
}
