using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{
    public class SimpleGreetService : IGreetService
    {
        public SimpleGreetService()
        {
            Console.WriteLine("Service created: " + this.GetHashCode());
        }
        public string Greet(string name)
        {
            return $"Hello World, {name} from Service #{this.GetHashCode()}";
        }
    }
}
