using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Domain.Models
{
    public class ChangePasswordModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Type the user current password.")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Type the user new password.")]

        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm the user new password.")]
        [Compare("NewPassword", ErrorMessage = "Password it is not equal.")]

        public string ConfirmNewPassword { get; set; }
    }
}
