
// Create an Instance of web application builder
using MiddlewreDemo.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

//Register custom middleware as service
builder.Services.AddTransient<MyMiddleware>();

//Create an instance of webapplication 
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello, I am Middleware 1");
    await next(context); //By adding Request delegates in Use() method we can perform the middleware chanining 
});

// Run() method will terminate the middleware
//Middleware 2
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello, I am Middleware 2");
});

//Middleware 3 - using Custom middleware class
//app.UseMiddleware<MyMiddleware>();
app.MyMiddleware();  //using extesion method

app.UseMyMiddleware2();

//Middleware 4
// As we have Already terminated middleare chaining using method Run() this Middleware 3 will not execute
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello, I am Middleware 3");
    await next(context); 
});