using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{

    public class GreetConfig
    {
        TimeName time;

        private string prefix;

        public GreetConfig(TimeName time)
        {
            this.time = time;
        }

        public string Prefix
        {
            get {
                if (TimedPrefix)
                    return "Good " + time.GetName();
                else
                    return prefix;
            
            }
            set { prefix = value; }
        }

        public string Suffix { get; set; }


        public bool TimedPrefix { get; set; }

    }

    public class ConfigurableGreetService3 : IGreetService
    {
        GreetConfig greetConfig;
        public ConfigurableGreetService3(IConfiguration config,TimeName time)
        {
            greetConfig = new GreetConfig(time);
            config.Bind("greeting", greetConfig);
        }

        
        public string Greet(string name)
        {
            return $"{greetConfig.Prefix} {name}, {greetConfig.Suffix}";
        }
    }
}
