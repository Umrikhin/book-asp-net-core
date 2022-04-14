/*

var builder = WebApplication.CreateBuilder(args);
//Регистрируем сервис аутентификации
builder.Services.AddAuthentication();
var app = builder.Build();
//Установка аутентификации пользователя
app.UseAuthentication();
//Установка поддержки маршрутизации
app.UseRouting();
//Задание конечных точек обработки маршрутов
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
});
app.Run();

*/

/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int val = 0;
app.MapGet("/", async context =>
{
    val++;
    await context.Response.WriteAsync($"Result: {val}");
});

app.Run();
*/


using MiddlewareComponent.Components;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseMiddleware<AgeMiddleware>();
app.MapGet("/", () => "Hello World!");

app.Run();


/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context => { await context.Response.WriteAsync("Hello World!"); });

app.Run();
*/


