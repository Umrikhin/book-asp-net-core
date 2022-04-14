using AlertService.Services;

var builder = WebApplication.CreateBuilder(args);
//����������� ������
builder.Services.AddSingleton<IAlert, XmlAlert>();
var app = builder.Build();
app.MapGet("/", async context =>
{
    //��������� ���������� ������
    IAlert msg = context.RequestServices.GetRequiredService<IAlert>();
    context.Response.ContentType = "text/html;charset=utf-8";
    string html = string.Empty;
    foreach (var service in builder.Services)
    {
        html += $"��� �������: {service.ServiceType.FullName}<br>";
        html += $"����� �����: {service.Lifetime}<br>";
        html += $"��� ����������: {service.ImplementationType?.FullName}<br><hr>";
    }
    await context.Response.WriteAsync(html);
    //await context.Response.WriteAsync(msg.GetMessage());
});

app.Run();
