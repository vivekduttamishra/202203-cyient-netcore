using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{
    public class ConfigurableGreetService : IGreetService
    {

        public ConfigurableGreetService(IConfiguration config)
        {
            Prefix=config["prefix"];
            Suffix = config["suffix"];
        }

        public string Prefix { get; set; } 
        public string Suffix { get; set; } 

        public string Greet(string name)
        {
            return $"{Prefix} {name}, {Suffix}";
        }
    }
}
