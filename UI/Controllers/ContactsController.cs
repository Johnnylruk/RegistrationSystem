using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Application.Repository;
using RegistrationSystem.Domain.Models;
using RegistrationSystem.UI.Filters;
using RegistrationSystem.UI.Helper;

namespace RegistrationSystem.UI.Controllers
{
    [LoggedInUsersPage]
    public class ContactsController : Controller
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ILogged _logged;
        public ContactsController(IContactsRepository _contactsRepository,
                                  ILogged _logged)
        {
            this._contactsRepository = _contactsRepository;
            this._logged = _logged;
        }

        public IActionResult Index()
        {
            UserModel LoggedUser = _logged.GetUserLogInSession();
            List<ContactModel> ListContact = _contactsRepository.ListAllContacts(LoggedUser.Id);
            return View(ListContact);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {

            ContactModel contacts = _contactsRepository.ListById(id);
            return View(contacts);
        }
        public IActionResult DeleteConfirm(int id)
        {
            ContactModel contacts = _contactsRepository.ListById(id);
            return View(contacts);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _contactsRepository.Delete(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Contact has been successful deleted";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = $"Error when trying to delete contact, try again";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to delete contact, try again, error details: {error.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel LoggedUser = _logged.GetUserLogInSession();
                    contact.UserId = LoggedUser.Id;
                    _contactsRepository.Add(contact);
                    TempData["SuccessMessage"] = "Contact has been successful added";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to register contact, try again, error details: {error.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel LoggedUser = _logged.GetUserLogInSession();
                    contact.UserId = LoggedUser.Id;
                    _contactsRepository.Update(contact);
                    TempData["SuccessMessage"] = "Contact has been successful updated";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to update contact, try again, error details: {error.Message}";
                return View(contact);
            }
        }
    }
}
