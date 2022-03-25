using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDay2.Controllers
{
    public class ErrorLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}