using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleHttpServer.Models;

namespace SimpleHttpServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public String handleLogin()
        {
            return "Login Successful on "+HttpContext.Request.Method+" call";
        }

        public String deleteUser()
        {
            if (HttpContext.Request.Method != "DELETE")
                return "Delete request on " + HttpContext.Request.Method + " call is denied";
            //write database logic to delete user.
            return "Deleted user on " + HttpContext.Request.Method + " call";

        }
    }
}
