using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Domain.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "This field is required. Please, type the user login.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "This field is required. Please, type the user password.")]
        public string Password { get; set; }
    }
}
