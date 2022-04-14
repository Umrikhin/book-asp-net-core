using HelloRazor.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IHello, HelloService>();
builder.Services.AddTransient<IAlert, AlertService>();
builder.Services.AddMvc().AddRazorRuntimeCompilation();
var app = builder.Build();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
