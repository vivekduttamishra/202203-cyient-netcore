using System.Threading.Tasks;

namespace BasicServer.services
{
    public interface IAuthenticationService
    {
        Task<string> Login(string email, string password);
        Task Logout(string token);
        Task<string> ValidateToken(string token);
    }
}