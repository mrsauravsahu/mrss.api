using GraphQL.Types;
using mrss.api.models;
using mrss.api.services;

namespace mrss.api.graphql
{
  public class RootQuery : ObjectGraphType<RootQuery>
  {
    private readonly AboutService aboutService;
    public About About { get; set; }
    public RootQuery(AboutService aboutService)
    {
      this.aboutService = aboutService;

      FieldAsync<About, About>(
        nameof(About),
      "About this app",
      resolve: aboutService.GetAsync);
    }
  }
}