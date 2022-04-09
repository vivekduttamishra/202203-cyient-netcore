using HelloAspnetMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloAspnetMVC.Controllers
{
    public class CyientController: Controller
    {

        //----> /cyient/home        
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