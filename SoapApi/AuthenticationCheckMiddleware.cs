using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace SoapApi
{
    public class AuthenticationCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var authenticateResult = await context.AuthenticateAsync();

            if (!authenticateResult.Succeeded)
            {
                context.Response.StatusCode = 401; // Set the desired status code (e.g., 401 Unauthorized)
                await context.Response.WriteAsync("Unauthenticated");
                await context.Response.Body.FlushAsync();
                return;
            }

            await _next(context);
        }
    }

}