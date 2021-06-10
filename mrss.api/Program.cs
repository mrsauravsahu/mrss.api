using System;
using System.IO;
using Microsoft.AspNetCore.Builder;

var app = WebApplication.Create();

var version = new Version(File.ReadAllText("VERSION"));
app.MapGet("/", new Func<dynamic>(() => new
{
  Data = new
  {
    Version = version
  }
}));

await app.RunAsync();