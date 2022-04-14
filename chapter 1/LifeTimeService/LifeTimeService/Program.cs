using LifeTimeService.Services;

var builder = WebApplication.CreateBuilder(args);
//Подключение сервисов
builder.Services.AddSingleton<IGuidService, GuidService>();
builder.Services.AddSingleton<UidService>();
var app = builder.Build();

app.MapGet("/", async context =>
{
    IGuidService guid = context.RequestServices.GetRequiredService<IGuidService>();
    UidService uid = context.RequestServices.GetRequiredService<UidService>();
    await context.Response.WriteAsync($"guid: { guid.Value}, uid: {uid.GUID.Value}");
});

app.Run();
