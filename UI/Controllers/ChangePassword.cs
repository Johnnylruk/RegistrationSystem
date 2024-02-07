using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Application.Repository;
using RegistrationSystem.Domain.Models;
using RegistrationSystem.UI.Helper;

namespace RegistrationSystem.UI.Controllers
{
    public class ChangePassword : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILogged _logger;
        public ChangePassword(IUsersRepository _usersRepository,
                              ILogged _logger)
        {
            this._usersRepository = _usersRepository;
            this._logger = _logger;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Changepwd(ChangePasswordModel changePassword)
        {
            try
            {
                UserModel userLogged = _logger.GetUserLogInSession();

                changePassword.Id = userLogged.Id;

                if (ModelState.IsValid)
                {
                    _usersRepository.ChangePassword(changePassword);
                    TempData["SuccessMessage"] = "User password has been successful changed.";
                    return View("Index", changePassword);

                }
                return View("Index", changePassword);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to change the user password. Please, try again. {error.Message}";
                return View("Index", changePassword);
            }
        }
    }
}
