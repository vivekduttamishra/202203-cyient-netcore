using BasicServer.utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.services
{
    public static class AuthenticationMiddlewares
    {
        public static IApplicationBuilder UseAuthneticationEndPoints(this IApplicationBuilder app)
        {

            app.UseOnUrl("/login", async context =>
            {

                string email = context.Request.Query["email"];
                string password = context.Request.Query["password"];

                var authenticator =(IAuthenticationService) app.ApplicationServices.GetService(typeof(IAuthenticationService));

                var token = await authenticator.Login(email, password);

                if (token != null)
                    await context.Response.WriteAsync(token);  //user can have the token. they must include it in all requests.
                else
                {
                    context.Response.StatusCode = 401; //anauthorized
                    await context.Response.WriteAsync("Unauthorized: Invalid username/password");
                }


            });


            app.UseOnUrl("/logout", async context =>
            {

                string token = context.Request.Headers["authorize"];

                var authenticator = (IAuthenticationService)app.ApplicationServices.GetService(typeof(IAuthenticationService));



                if (token != null)
                {
                    await authenticator.Logout(token);
                    await context.Response.WriteAsync("You are Logged Out");
                }                    
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("No token Present");
                }
                


            });

            return app;

        }

        public static IApplicationBuilder UseAuthenticate(this IApplicationBuilder app)
        {

            app.Use(next => async context =>
            {
                var token = context.Request.Headers["authorize"]; //search for authorize header
                var service =(IAuthenticationService) context.RequestServices.GetService(typeof(IAuthenticationService));


                if (string.IsNullOrEmpty(token))
                {
                    context.Response.StatusCode = 401; //aunauthorized
                    await context.Response.WriteAsync("No token Found");
                    return;
                }

                var email = await service.ValidateToken(token);
                if (string.IsNullOrEmpty(email))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid Token");
                    return;
                }

                //since user is authenticated, they can move to next step

                //other middlewares can access the user info in request header

                context.Request.Headers["user"] = email; //add extra parameter to user request

                //let the next middleware work
                await next(context);  





            });


            return app;
        }


    }
}
