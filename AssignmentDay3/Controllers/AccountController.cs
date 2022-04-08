using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AssignmentDay3.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string UserName,string Password)
        {
            if(UserName !=null && Password!=null)
            {
                if(UserName=="admin" && Password=="1234")
                {
                    HttpContext.Session.SetString("UserName", UserName);
                    HttpContext.Session.SetString("Role", "Admin");
                    return View("Welcome");
                }
                else if(UserName == "editor" && Password == "1234")
                {
                    HttpContext.Session.SetString("UserName", UserName);
                    HttpContext.Session.SetString("Role", "Editor");
                    return View("Welcome");
                }
            }
            ViewBag.error = "Invalid";
            return View("Index");
        }
        public IActionResult Welcome()
        {
            return View();
        }
    }
}