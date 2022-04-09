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
        public string Welcome()
        {
            return "<h1>Welcome to Cyient</h1>";
        }


        //----> /cyient/hello
        public string Hello(string id)
        {
            return $"Hello {id}, Welcome to Cyient!";
        }

        //---->  /cyient/timeserver
        public DateTime TimeDetails()
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
            string data = $"<h1>Admin Contact</h1>" +
                        $"<h2>{person.Name}</h2>" +
                        $"<h3>{person.Email}</h3";

            return Content(data,"text/html");

        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Now()
        {
            return View("DateTime");
        }


        public ViewResult TellTheTime()
        {
            ViewData["date"] = DateTime.Now;
            ViewData["contact"] = "vivek@conceptarchitect.in";
            ViewBag.Title = "Today";
            return View("TimeServer");
        }


        public ViewResult Today()
        {
            var model = new TimeInfo()
            {
                Time = DateTime.Now,
                Title = "Today"
            };
            return View("TimeInfo", model);
        }

        public ViewResult Tomorrow()
        {
            var model = new TimeInfo()
            {
                Time = DateTime.Now.AddDays(1),
                Title = "Tomorrow"
            };

            return View("TimeInfo", model);
        }

        public ViewResult After(int days)
        {
            var model = new TimeInfo()
            {
                Time = DateTime.Now.AddDays(days),
                Title = $"After {days} days"
            };

            return View("TimeInfo", model);
        }

        public string Age(DateTime birthDate)
        {
            var age = DateTime.Now - birthDate;

            return $"{age.TotalDays/365} Years Approx";
        }

        public ActionResult AfterDays(int? id)
        {
            
            
            if(id==null)
            {
                //what is id is not passed?
                //return Today();

                //return RedirectToAction("Today");

                Response.StatusCode = 400; //Bad Request
                return View("Error", (object)"You must pass the day value");
            }

            int days = id.Value;

            var model = new TimeInfo()
            {
                Time = DateTime.Now.AddDays(days),
                Title = $"After {days} days"
            };

            return View("TimeInfo", model);

        }


    }
}
