using System.ComponentModel.DataAnnotations;

namespace IdentityProject.ViewModels
{
    public class SignInVM
    {
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }
    }
}
