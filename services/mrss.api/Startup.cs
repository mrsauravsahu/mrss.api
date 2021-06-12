using System;
using System.IO;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using mrss.api.models;

namespace mrss.api
{
  public class Startup
  {
    public Version AppVersion { get; set; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      AppVersion = new Version(File.ReadAllText("./VERSION"));
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc(
            $"v{AppVersion}",
            new OpenApiInfo
            {
              Title = "mrss.api",
              Version = $"v{AppVersion}"
            });
      });

      // TODO: Configure GraphQL
      services
      .AddSingleton<PortfolioSchema>()
      .AddGraphQL()
      .AddGraphTypes(typeof(PortfolioSchema))
      .AddSystemTextJson();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v{AppVersion}/swagger.json", "mrss.api"));
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseGraphQL<PortfolioSchema>();
      // app.UseGraphQLGraphiQL();
      app.UseGraphQLPlayground();
    }
  }
}
