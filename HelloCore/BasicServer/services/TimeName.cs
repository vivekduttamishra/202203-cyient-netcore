using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{
    public class TimeName
    {
        public string GetName()
        {
            var hour = DateTime.Now.Hour;
            string message = "";
            if (hour < 12)
                message = "Morning";
            else if (hour < 18)
                message = "After noon";
            else
                message = "Evening";

            return message;
        }
    }
}
