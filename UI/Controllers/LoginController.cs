using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Application.Repository;
using RegistrationSystem.Domain.Models;
using RegistrationSystem.UI.Helper;

namespace RegistrationSystem.UI.Controllers
{

    public class LoginController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILogged _logged;
        private readonly IEmail _email;
        public LoginController(IUsersRepository _usersRepository,
                               ILogged _logged,
                               IEmail _email)
        {
            this._usersRepository = _usersRepository;
            this._logged = _logged;
            this._email = _email;
        }
        public IActionResult Index()
        {
            if (_logged.GetUserLogInSession() != null) return RedirectToAction("Index", "Home");

            return View();
            
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult LoggedOut()
        {
            _logged.CreateLogOutSession();

            return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public IActionResult LogIn(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _usersRepository.GetByLogIn(loginModel.Login);
                    Password password = new Password();

                    if (user != null)
                    {
                        if (password.ValidPassword(user.Password, loginModel.Password))
                        {
                            _logged.CreateLogInSession(user);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["ErrorMessage"] = "Invalid password. Please, try again";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Invalid Log in and/or password. Please, try again";
                    }
                }
                 return View("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to log in, error details:{error.Message}. Please, try again. ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult SendLinkToResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _usersRepository.GetByLoginAndEmail(resetPassword.Login, resetPassword.Email);
                    Password password = new Password();

                    if (user != null)
                    {
                        string newPassword = password.GenerateNewPassword();
                        string message = $"Your new Password is: {newPassword}";

                        bool SentEmail = _email.SendEmail(user.Email, "Registration System - Reset your password", message);

                        if (SentEmail)
                        {
                            _usersRepository.Update(user);
                            TempData["SuccessMessage"] = $"We have sent the new password to your registered email.";
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Could not sent your new password. Please, try again";
                        }
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["ErrorMessage"] = "Could not sent your new password. Please, verify the input details and try again";

                }
                return View("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to reset password, error details:{error.Message}. Please, try again. ";
                return RedirectToAction("Index");
            }
        }



    }
}
