using HelloMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Controllers
{
    public class CyientController : Controller
    {
        //----> /cyient/home
        //----> /cyient        <---- default action is Home
        public string Home()
        {
            return "<h1>Welcome to Cyient</h1>";
        }


        //----> /cyient/hello
        public string Hello(string id)
        {
            return $"Hello {id}, Welcome to Cyient!";
        }

        //---->  /cyient/timeserver
        public DateTime TimeServer()
        {
            return DateTime.Now;
        }

       

        public Person Contact()
        {
            return new Person()
            {
                Name = "Vivek Dutta Mishra",
                Email = "vivek@web.com"
            };
        }
      
    }
}
