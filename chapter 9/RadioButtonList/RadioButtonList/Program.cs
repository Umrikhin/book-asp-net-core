using RadioButtonList.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IFruits, Fruits>();
builder.Services.AddMvc();
var app = builder.Build();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
