using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.Controllers
{
    public class HelpController
    {
        public string Interface()
        {
            return "This is about UI Documentation";
        }

        public string Api()
        {
            return "This is API documentation";
        }
    }
}
