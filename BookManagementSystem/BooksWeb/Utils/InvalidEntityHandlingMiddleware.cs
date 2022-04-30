using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

using System.Text.Json;

namespace BooksWeb.Utils
{
    public static class InvalidEntityHandlingMiddleware
    {
        public static void Use404ForInvalidEntityException(this IApplicationBuilder app)
        {
            app.Use(next => async context =>
            {

                try
                {
                    await next(context);
                }catch(InvalidEntityException ex)
                {
                    context.Response.StatusCode = 404;
                    var response = new { Message = ex.Message, Id = ex.Id };
                    
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response)); 
                }


            });
        }
    }
}
