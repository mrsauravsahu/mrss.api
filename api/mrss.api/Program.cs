using System;
using Microsoft.AspNetCore.Builder;

var app = WebApplication.Create();

app.MapGet("/", new Func<dynamic>(() => new
{
  Data = new
  {
    App = "mrss"
  }
}));

await app.RunAsync();