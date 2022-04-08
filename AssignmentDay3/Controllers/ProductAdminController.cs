using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDay3.Controllers
{
    public class ProductAdminController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowView()
        {
            return View();
        }
        public IActionResult NoFound()
        {
            return NotFound();
        }
    }
}