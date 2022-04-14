using AlertService.Services;

var builder = WebApplication.CreateBuilder(args);
//Подключение службы
builder.Services.AddSingleton<IAlert, XmlAlert>();
var app = builder.Build();
app.MapGet("/", async context =>
{
    //Получение экземпляра службы
    IAlert msg = context.RequestServices.GetRequiredService<IAlert>();
    context.Response.ContentType = "text/html;charset=utf-8";
    string html = string.Empty;
    foreach (var service in builder.Services)
    {
        html += $"Тип сервиса: {service.ServiceType.FullName}<br>";
        html += $"Время жизни: {service.Lifetime}<br>";
        html += $"Тип реализации: {service.ImplementationType?.FullName}<br><hr>";
    }
    await context.Response.WriteAsync(html);
    //await context.Response.WriteAsync(msg.GetMessage());
});

app.Run();
