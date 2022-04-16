using HelloMVC.Data;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Controllers
{
    public class MathController:Controller
    {

        IMultiplicationTableGenerator generator;
        SimpleMath math;
        public MathController(IMultiplicationTableGenerator generator,SimpleMath math)
        {
            this.generator = generator;
            this.math = math;
        }

        public IActionResult Table1(int id)
        {
            string html = $"<html><head><title>Table of {id}</title><head>" +
                            $"<body><h1>Table of {id}</h1>" +
                            $"<table><thead><tr><th>Number</th><th>Multiplplier</th><th>Result</th></thead>" +
                            $"<tbody>";

            for (int i = 1; i <= 10; i++)
                html += $"<tr><td>{id}</td> <td>{i}</td><td>{id * i}</td></tr>";

            html += "</tbody></table></body></html>";

            return Content(html, "text/html");
        }

        public IActionResult Table2(int id)
        {
            string html =   $"<h1>Table of {id}</h1>" +
                            $"<table><thead><tr><th>Number</th><th>Multiplplier</th><th>Result</th></thead>" +
                            $"<tbody>";

            for (int i = 1; i <= 10; i++)
                html += $"<tr><td>{id}</td> <td>{i}</td><td>{id * i}</td></tr>";

            html += "</tbody></table>";


            //This content will be encoded by Razor Engine
            //return View((object)html);


            //If you want to show generate html without encoding send as HtmlString
            var model = new HtmlString(html);
            return View(model);
        }


        public IActionResult Table3(int id)
        {
            return View(id);
        }
    
    
        public IActionResult Table(int number1, int number2 )
        {
            var x = RouteData;
            //controller should know which service method to call
            //it doesn't know the internal working
            var times = number2==0 ?  10 : number2;

            var table = generator.Generate(number1,times);

            return View(table);


        }
    

        public int Plus(int number1,int number2)
        {
            return math.Plus(number1, number2);
        }

        public int Minus(int number1, int number2)
        {
            return math.Minus(number1, number2);
        }

        public int Multiply(int number1, int number2)
        {
            return math.Multiply(number1, number2);
        }

        public int Divide(int number1, int number2)
        {
            return math.Divide(number1, number2);
        }

        public int Factorial(int number1)
        {
            return math.Factorial(number1);
        }

    }
}
