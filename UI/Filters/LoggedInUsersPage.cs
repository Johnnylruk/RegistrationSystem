using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using RegistrationSystem.Domain.Models;

namespace RegistrationSystem.UI.Filters
{
    public class LoggedInUsersPage : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string UserSession = context.HttpContext.Session.GetString("UserLoggedInSession");

            if (string.IsNullOrEmpty(UserSession))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(UserSession);

                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });

                }
            }
            base.OnActionExecuting(context);
        }
    }
}
