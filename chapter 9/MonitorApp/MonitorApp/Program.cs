using MonitorApp.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<TimedHostedService>();
builder.Services.AddSingleton<IMonitorPanel, MonitorPanel>();
builder.Services.AddMvc();
var app = builder.Build();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

