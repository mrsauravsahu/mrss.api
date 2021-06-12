using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

var version = new Version(File.ReadAllText("VERSION"));

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(config =>
{
  config.SwaggerDoc($"v{version}", new OpenApiInfo
  {
    Version = version.ToString(),
    Title = "mrss.api",
    Contact = new OpenApiContact
    {
      Name = "Saurav Sahu",
      Url = new Uri("https://mrsauravsahu.tech"),
      Email = "mrsauravsahu@outlook.com"
    }

  });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(config =>
{
  config.SwaggerEndpoint($"/swagger/v{version.ToString()}/swagger.json", "mrss.api");
});

app.MapGet("/", (Func<dynamic>)(() => new
{
  Data = new { Version = version }
}));

await app.RunAsync();