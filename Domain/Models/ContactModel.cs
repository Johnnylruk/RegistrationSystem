using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Domain.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required. Please, type the contact name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required. Please, type the contact email.")]
        [EmailAddress(ErrorMessage = "The E-mail typed it is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required. Please, type the contact mobile.")]
        [Phone(ErrorMessage = "The mobile number it is not valid")]
        public string Mobile { get; set; }
        public int? UserId { get; set; }
        public UserModel? User { get; set; }


    }
}
