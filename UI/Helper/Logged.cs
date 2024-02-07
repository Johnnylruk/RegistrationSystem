using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using RegistrationSystem.Domain.Models;

namespace RegistrationSystem.UI.Helper
{
    public class Logged : ILogged
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public Logged(IHttpContextAccessor _contextAccessor)
        {
            this._contextAccessor = _contextAccessor;
        }
        public void CreateLogInSession(UserModel user)
        {
            string convert = JsonConvert.SerializeObject(user);

            _contextAccessor.HttpContext.Session.SetString("UserLoggedInSession", convert);
        }

        public void CreateLogOutSession()
        {
            _contextAccessor.HttpContext.Session.Remove("UserLoggedInSession");
        }

        public UserModel GetUserLogInSession()
        {
            string LogInSession = _contextAccessor.HttpContext.Session.GetString("UserLoggedInSession");
            if (string.IsNullOrEmpty(LogInSession)) return null;

            return JsonConvert.DeserializeObject<UserModel>(LogInSession);

        }
    }
}
