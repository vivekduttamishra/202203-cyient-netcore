using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.Controllers
{
    public class WelcomeController
    {
        public string Guests()
        {
            return "Welcome Guests! to our Service";
        }

        public string Developers()
        {
            return "Welcome Developers to your den!";
        }

        public string Wizards()
        {
            return "Welcome Wizards to the magical world of Asp.NET Core";
        }
    }
}
