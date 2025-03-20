
namespace MiddlewreDemo.CustomMiddleware
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
           await context.Response.WriteAsync("Custom middleware started.....!");
           await next(context);  // it will call next middleware in pipeline
           await context.Response.WriteAsync("Custom middleware Finished.....!");
        }
    }
}
