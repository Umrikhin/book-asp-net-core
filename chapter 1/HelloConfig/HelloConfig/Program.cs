using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//Подключение конфигурации
var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";
builder.WebHost.UseConfiguration(new HelloConfig.Settings(path).config);
var app = builder.Build();
//Изменение и отображение параметров конфигурации
IConfiguration configuration = app.Configuration;
//configuration["Country"] = "Норвегия";
//configuration["City"] = "Осло";
//string country = $"Страна: {configuration["Country"]}<br>";
//string city = $"Город: {configuration["City"]}<br>";
//string html = $"<!DOCTYPE html><html><head><meta charset=utf-8></head><body>{country + city}</body></html>";
string city = $"Город: {configuration.GetSection("Country")["City"]}<br>";
string html = $"<!DOCTYPE html><html><head><meta charset=utf-8></head><body><p style='color:{configuration.GetSection("Country")["Status"]}'>{city}</p></body></html>";
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(html);
});
app.Run();
