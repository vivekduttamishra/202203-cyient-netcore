using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{
    public class ConfigurableGreetService2 : IGreetService
    {

        public ConfigurableGreetService2(IConfiguration config,TimeName time)
        {
            Prefix=config["greeting:prefix"];
            Suffix = config["greeting:suffix"];
            TimedPrefix =bool.Parse( config["greeting:timedPrefix"]);
           
            if (TimedPrefix)
                Prefix ="Good "+ time.GetName();
        }

        public string Prefix { get; set; } 
        public string Suffix { get; set; }

        public bool TimedPrefix { get; set; }

        public string Greet(string name)
        {
            return $"{Prefix} {name}, {Suffix}";
        }
    }
}
