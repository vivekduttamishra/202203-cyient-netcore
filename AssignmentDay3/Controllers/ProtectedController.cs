using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDay3.Controllers
{
    public class ProtectedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}