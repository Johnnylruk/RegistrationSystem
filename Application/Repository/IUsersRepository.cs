using RegistrationSystem.Domain.Models;

namespace RegistrationSystem.Application.Repository
{
    public interface IUsersRepository
    {
        UserModel GetByLogIn(string login);
        UserModel GetByLoginAndEmail(string login, string email);

        UserModel ListById(int id);
        List<UserModel> ListAllUsers();
        UserModel Add(UserModel users);
        UserModel Update(UserModel users);
        bool Delete(int id);
        UserModel ChangePassword(ChangePasswordModel changePasswordModel);

    }
}
