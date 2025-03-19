
// Create an Instance of web application builder
var builder = WebApplication.CreateBuilder(args);

//Create an instance of webapplication 
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello, I am Middleware 1");
    await next(context); //By adding Request delegates in Use() method we can perform the middleware chanining 
});

// Run() method will terminate the middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello, I am Middleware 2");
});


// As we have Already terminated middleare chaining using method Run() this Middleware 3 will not execute
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello, I am Middleware 3");
    await next(context); 
});