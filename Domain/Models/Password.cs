using RegistrationSystem.UI.Helper;

namespace RegistrationSystem.Domain.Models
{
    public class Password
    {

        public bool ValidPassword(string hashedPassword, string inputPassword)
        {
            inputPassword = inputPassword.GenerateHash();
            return inputPassword == hashedPassword;
        }

        public void SetPasswordHash()
        {   
            UserModel SetPassword = new UserModel();
            SetPassword.Password = SetPassword.Password.GenerateHash();
        }

        public string GenerateNewPassword()
        {
            UserModel GeneratePassword = new UserModel();
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            GeneratePassword.Password = password.GenerateHash();
            return password;
        }

        public void SetNewPassword(string newPassword)
        {
            UserModel NewPassword = new UserModel();
            NewPassword.Password = newPassword.GenerateHash();
        }
    }
}
