using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }

    public class User : UserInfo
    {
        public string Password { get; set; }
    }

    public class DbAuthenticationService : IAuthenticationService
    {
        List<User> users;
        Dictionary<string, User> tokens = new Dictionary<string, User>();

        public DbAuthenticationService()
        {
            users = new List<User>()
            {
                new User(){ Name="Vivek Dutta Mishra", Email="vivek@conceptarchitect.in",Password="p@ss", Roles={ "admin","editor"} },
                new User(){ Name="Amit Singh", Email="amit@gmail.com",Password="p@ss", Roles={ "developer","writer"} }

            };
        }

       

        public Task<string> Login(string email, string password)
        {
            var user = (from u in users
                        where u.Email == email && u.Password == password
                        select u).FirstOrDefault();

            return null;
        }

        public Task Logout(string token)
        {
            throw new NotImplementedException();
        }

        public Task<string> ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
