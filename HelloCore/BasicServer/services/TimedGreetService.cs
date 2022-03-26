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
        TimeName time;
        public TimedGreetService(IFormatterService formatter,ILogger<TimedGreetService> logger,TimeName time)
        {
            this.formatter = formatter;
            this.logger = logger;
            this.time = time;
        }

        public string Greet(string name)
        {
            var message = time.GetName();

            var response=formatter.Format($"Good {message}, {name}");

            logger.LogInformation($"Service# {GetHashCode()}  : {response}");

            return response;
        }
    }
}
