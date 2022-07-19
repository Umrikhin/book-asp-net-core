using Authorization.Services;
var webApplicationOptions = new WebApplicationOptions() { ContentRootPath = AppContext.BaseDirectory, Args = args, ApplicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName };
var builder = WebApplication.CreateBuilder(webApplicationOptions);
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.Listen(System.Net.IPAddress.Any, 5095);
//    options.Listen(System.Net.IPAddress.Any, 5080, listenOptions =>
//    {
//        listenOptions.UseHttps("certificate.pfx", "qwerty1");
//    });
//});
builder.Host.UseWindowsService();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUsersPortalRepository, UsersPortalRepository>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});
builder.Services.AddMvc();
var app = builder.Build();
app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();