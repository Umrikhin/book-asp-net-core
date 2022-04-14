/*

var builder = WebApplication.CreateBuilder(args);
//������������ ������ ��������������
builder.Services.AddAuthentication();
var app = builder.Build();
//��������� �������������� ������������
app.UseAuthentication();
//��������� ��������� �������������
app.UseRouting();
//������� �������� ����� ��������� ���������
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


