using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{
    public class DummyAuthenticationService : IAuthenticationService
    {
        Dictionary<string, string> users = new Dictionary<string, string>();   //list of all users in our system
        Dictionary<string, string> tokens = new Dictionary<string, string>();  //list of active tokens in our system. 
        Random random = new Random();
        public DummyAuthenticationService()
        {
            users["vivek@conceptarchitect.in"] = "p@ss";
            users["admin@admin.com"] = "p@ss";
        }

        public async Task<string> Login(string email, string password)
        {
            await Task.Delay(1000);
            if (users.ContainsKey(email) && users[email] == password)
            {
                string token = null;
                while (true)
                {

                    int t = random.Next(100000, 999999);
                    token = t.ToString();
                    if (!tokens.ContainsKey(token))
                        break;
                }
                tokens[token] = email;  //since user has logged in. store the token for future verification
                return token;

            }
            else
            {
                return null;
            }
        }

        public async Task<string> ValidateToken(string token)
        {
            await Task.Delay(1000);
            if (tokens.ContainsKey(token))
                return tokens[token]; //email of logged in user
            else
                return null;
        }

        public async Task Logout(string token)
        {
            await Task.Delay(200);
            if (tokens.ContainsKey(token))
                tokens.Remove(token);
        }



    }

}





