using SiteCourse.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICourse, MockCourse>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
