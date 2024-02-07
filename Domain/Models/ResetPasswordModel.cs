using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Domain.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "This field is required. Please, type the user login.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "This field is required. Please, type the user email.")]
        [EmailAddress(ErrorMessage = "The E-mail typed it is not valid")]
        public string Email { get; set; }
    }
}

