using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Domain.Models;
using RegistrationSystem.UI.Filters;
using System.Diagnostics;

namespace RegistrationSystem.UI.Controllers
{
    [LoggedInUsersPage]
    public class HomeController : Controller
    {



        public IActionResult Index()
        {
            ContactModel home = new ContactModel();

            home.Name = "Johnny Rodrigues";
            home.Email = "Test123@gmail.com";

            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}