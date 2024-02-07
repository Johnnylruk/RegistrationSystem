using RegistrationSystem.Domain.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Domain.Models
{
    public class NoPwdUserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required. Please, type the user name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required. Please, type the user login.")]

        public string Login { get; set; }
        [Required(ErrorMessage = "This field is required. Please, type the user email.")]
        [EmailAddress(ErrorMessage = "The E-mail typed it is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required. Please, select the user profile.")]
        public EnumProfile? Profile { get; set; }

    }
}
