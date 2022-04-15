using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDay3.Controllers
{
    public class MathsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult mulitplicationtable(string num="",int count=0)
        {
            if (num != "")
            {
                var isNumeric = int.TryParse(num, out int n);
                if (isNumeric)
                {
                    ViewBag.Num =Convert.ToInt32(num);
                    ViewBag.Count = count;
                    return View();
                }
                else
                    return NotFound("Supplied parameters are not numbers ");

            }
            else
                return NotFound("No parameter is supplied");
            
        }
    }
}