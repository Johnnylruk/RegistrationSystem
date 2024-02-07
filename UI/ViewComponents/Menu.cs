using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegistrationSystem.Domain.Models;

namespace RegistrationSystem.UI.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string LogSession = HttpContext.Session.GetString("UserLoggedInSession");

            if (string.IsNullOrEmpty(LogSession)) return null;

            UserModel user = JsonConvert.DeserializeObject<UserModel>(LogSession);
            return View(user);


        }
    }
}
