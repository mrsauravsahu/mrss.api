using System;
using System.IO;
using System.Threading.Tasks;
using GraphQL;
using mrss.api.graphql;
using mrss.api.models;
using mrss.types;
using Propfull.AspNet.Config;

namespace mrss.api.services
{
  public class AboutService
  {
    private readonly ConfigService<AppConfig> configService;

    public AboutService(ConfigService<AppConfig> configService) =>
    this.configService = configService;
    internal async Task<About> GetAsync(IResolveFieldContext<RootQuery> _)
    {
      var config = await configService.GetConfigAsync();
      return new About
      {
        Name = config.Name,
        Version = $"v{File.ReadAllText(Path.Join(Environment.CurrentDirectory, "VERSION"))}"
      };
    }
  }
}