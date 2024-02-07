using RegistrationSystem.Domain.Models.Enum;
using RegistrationSystem.UI.Helper;
using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Domain.Models
{
    public class UserModel
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

        [Required(ErrorMessage = "This field is required. Please, type the user password.")]
        public string Password { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime? DateUpdated { get; set; }


        public virtual List<ContactModel> Contacts { get; set; }

/*        public bool ValidPassword(string password)
        {
            return Password == password.GenerateHash();
        }*/

    /*    public void SetPasswordHash()
        {
            Password = Password.GenerateHash();
        }*/
/*
        public string GenerateNewPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            Password = password.GenerateHash();
            return password;
        }*/
/*
        public void SetNewPassword(string newPassword)
        {
            Password = newPassword.GenerateHash();
        }*/
    }
}
