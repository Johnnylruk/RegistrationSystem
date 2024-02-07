using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.UI.Filters;

namespace RegistrationSystem.UI.Controllers
{
    public class RestrictController : Controller
    {
        [LoggedInUsersPage]

        public IActionResult Index()
        {
            return View();
        }
    }
}
