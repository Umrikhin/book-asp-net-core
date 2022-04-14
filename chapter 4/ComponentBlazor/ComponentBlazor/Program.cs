var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServerSideBlazor();
builder.Services.AddMvc();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapBlazorHub();
app.Run();
