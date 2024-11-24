using JWTAuthentication.Models;

namespace JWTAuthentication.Service
{
    public interface ILoginService
    {
        public bool LoginUser(string UserName, string Password);
    }
}
