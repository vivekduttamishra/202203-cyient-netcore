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

        //----> /cyient/hello
        public string Hello(string id)
        {
            return $"Hello {id}, Welcome to Cyient!";
        }



        //----> /cyient/home        
        


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


        public string Welcome()
        {
            return "<h1>Welcome to Cyient</h1>";
        }

        public ContentResult Home()
        {
            return new ContentResult()
            {
                Content = "<h1>Welcome to Cyient</h1>",
                ContentType = "text/html"
            };
        }

     

        public ContentResult AdminContact()
        {
            var person = new Person() { Name = "Admin", Email = "admin@web.com" };
            string data =   $"<h1>Admin Contact</h1>" +
                            $"<h2>{person.Name}</h2>" +
                            $"<h3>{person.Email}</h3";

            return Content(data);

        }



        public ViewResult Index()
        {

        }









    }
}