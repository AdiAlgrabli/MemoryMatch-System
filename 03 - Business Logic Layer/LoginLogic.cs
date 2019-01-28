using System.Linq;

namespace JohnBryce
{
    public class LoginLogic : BaseLogic
    {
        public LoginModel Login(string username, string password)
        {
            return DB.Users
                .Where(u => u.Username.ToLower() == username.ToLower() && u.Password.ToLower() == password.ToLower())                
                .Select(u => new LoginModel
                {
                    userId = u.UserID,
                    username = u.Username,
                    password = u.Password
                }).SingleOrDefault();
        }
    }
}
