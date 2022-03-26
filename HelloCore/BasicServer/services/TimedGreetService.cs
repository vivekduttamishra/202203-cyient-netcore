using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{
    public class TimedGreetService : IGreetService
    {
        IFormatterService formatter;
        ILogger<TimedGreetService> logger;
        public TimedGreetService(IFormatterService formatter,ILogger<TimedGreetService> logger)
        {
            this.formatter = formatter;
            this.logger = logger;
        }

        public string Greet(string name)
        {
            var hour = DateTime.Now.Hour;
            string message = "";
            if (hour < 12)
                message = "Morning";
            else if (hour < 18)
                message = "After noon";
            else
                message = "Evening";

            var response=formatter.Format($"Good {message}, {name}");

            logger.LogInformation($"Service# {GetHashCode()}  : {response}");

            return response;
        }
    }
}
