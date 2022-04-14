using Microsoft.AspNetCore.Mvc;
using SiteCourse.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICourse, MockCourse>();
//builder.Services.AddControllers();
//builder.Services.AddControllers().AddXmlSerializerFormatters();
//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add(new ProducesAttribute("application/xml"));
//}).AddXmlSerializerFormatters();
builder.Services.AddControllers(options =>
{
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
}).AddXmlSerializerFormatters();
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
