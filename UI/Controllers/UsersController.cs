using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Application.Repository;
using RegistrationSystem.Domain.Models;
using RegistrationSystem.UI.Filters;

namespace RegistrationSystem.UI.Controllers
{
    [OnlyAdminPage]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _userRepository;
        private readonly IContactsRepository _contactsRepository;
        public UsersController(IUsersRepository _userRepository,
                               IContactsRepository _contactsRepository)
        {
            this._userRepository = _userRepository;
            this._contactsRepository = _contactsRepository;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.ListAllUsers();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ListContactsByUserId(int id)
        {
            List<ContactModel> contacts = _contactsRepository.ListAllContacts(id);
            return PartialView("_UsersContacts", contacts);
        }



        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user = _userRepository.Add(user);
                    TempData["SuccessMessage"] = "User has been successful added";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to register user, try again, error details: {error.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteConfirm(int id)
        {
            UserModel user = _userRepository.ListById(id);
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _userRepository.Delete(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "User has been successful deleted";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = $"Error when trying to delete user, try again";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to delete user, try again, error details: {error.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Edit(int id)
        {

            UserModel user = _userRepository.ListById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(NoPwdUserModel NoPwdUser)
        {
            try
            {
                UserModel user = null;


                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = NoPwdUser.Id,
                        Name = NoPwdUser.Name,
                        Login = NoPwdUser.Login,
                        Email = NoPwdUser.Email,
                        Profile = NoPwdUser.Profile,
                    };

                    user = _userRepository.Update(user);
                    TempData["SuccessMessage"] = "User has been successful updated";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to update user, try again, error details: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}