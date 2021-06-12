using System;
using System.IO;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mrss.api.graphql;
using mrss.api.services;
using mrss.types;
using Propfull.AspNet.Config;

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
      // App Config
      services.Configure<AppConfig>(Configuration.GetSection(nameof(AppConfig)));
      services.AddSingleton(options => options.GetConfigService<AppConfig>());

      // Services
      services.AddSingleton<AboutService>();

      services.AddControllers();

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
      if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseGraphQL<PortfolioSchema>();
      app.UseGraphQLPlayground();
    }
  }
}
