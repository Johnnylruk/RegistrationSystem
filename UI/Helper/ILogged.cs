using RegistrationSystem.Domain.Models;

namespace RegistrationSystem.UI.Helper
{
    public interface ILogged
    {
        void CreateLogInSession(UserModel user);
        void CreateLogOutSession();
        UserModel GetUserLogInSession();

    }
}
