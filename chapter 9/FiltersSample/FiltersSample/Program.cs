var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddScoped<FiltersSample.Utils.ConfigFilterAsync>();
builder.Services.AddMvc();
var app = builder.Build();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
