using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RegistrationSystem.Domain.Models;
using RegistrationSystem.Infrastructure.Data;
using System.Security.Cryptography.Xml;

namespace RegistrationSystem.Application.Repository
{
    public class UserRepository : IUsersRepository
    {
        private DataBaseContext dataBaseContext;

        public UserRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }


        public UserModel GetByLogIn(string login)
        {
            return dataBaseContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel GetByLoginAndEmail(string login, string email)
        {
            return dataBaseContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
        }
        public UserModel ListById(int id)
        {
            return dataBaseContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> ListAllUsers()
        {
            return dataBaseContext.Users
                  .Include(x => x.Contacts)
                  .ToList();
        }


        public UserModel Add(UserModel user)
        {
            Password password = new Password();
            user.DateRegistered = DateTime.Now;
            password.SetPasswordHash();
            dataBaseContext.Users.Add(user);
            dataBaseContext.SaveChanges();
            return user;
        }

        public UserModel Update(UserModel user)
        {
            UserModel userDB = ListById(user.Id);
            if (userDB == null) throw new Exception("Error to update user");

            userDB.Name = user.Name;
            userDB.Login = user.Login;
            userDB.Email = user.Email;
            userDB.Profile = user.Profile;
            userDB.DateUpdated = DateTime.Now;

            dataBaseContext.Users.Update(userDB);
            dataBaseContext.SaveChanges();
            return userDB;
        }

        public UserModel ChangePassword(ChangePasswordModel changePasswordModel)
        {
            Password password = new Password();

            UserModel userDB = ListById(changePasswordModel.Id);
            if (userDB == null) throw new Exception("Error trying to find user: User not found.");

            if (password.ValidPassword(changePasswordModel.CurrentPassword, userDB.Password)) throw new Exception("Wrong current password.");

            if (password.ValidPassword(changePasswordModel.NewPassword, userDB.Password)) throw new Exception("New password must be different from current password.");

            password.SetNewPassword(changePasswordModel.NewPassword);
            userDB.DateUpdated = DateTime.Now;

            dataBaseContext.Users.Update(userDB);
            dataBaseContext.SaveChanges();
            return userDB;
        }

        public bool Delete(int id)
        {
            UserModel userDB = ListById(id);
            if (userDB == null) throw new Exception("Error when trying to delete user");

            dataBaseContext.Users.Remove(userDB);
            dataBaseContext.SaveChanges();
            return true;


        }


    }
}
