using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewreDemo.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware2
    {
        private readonly RequestDelegate _next;

        public MyMiddleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await httpContext.Response.WriteAsync("Custom middleware started.....!");
            await _next(httpContext);  // it will call next middleware in pipeline
            await httpContext.Response.WriteAsync("Custom middleware Finished.....!");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddleware2Extensions
    {
        public static IApplicationBuilder UseMyMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware2>();
        }
    }
}
