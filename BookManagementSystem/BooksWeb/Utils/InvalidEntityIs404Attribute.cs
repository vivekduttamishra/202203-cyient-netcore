using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWeb.Utils
{
    public class InvalidEntityIs404Attribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //first find out which exception is thrown
            var ex = context.Exception as InvalidEntityException;
            if(ex==null)
            {
                //out of syllabus. I dont care about other exception
                return;
            }

            //Now I know InvalidEntityException was thrown
            //If I generate result, system will not generate 500

            context.Result = new NotFoundObjectResult(new { Message = ex.Message, Id = ex.Id });


        }
    }
}
