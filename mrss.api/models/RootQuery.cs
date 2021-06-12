using System.IO;
using GraphQL.Types;
using mrss.api.models.types;

namespace mrss.api.models
{
  public class RootQuery : ObjectGraphType<RootQuery>
  {
    public About About { get; set; }
    public RootQuery()
    {
      // Create a service for this
      Field<About>(nameof(About), "About this app", resolve: (_) => new About
      {
        Name = "mrss.api",
        Version = "v0.0.1",
      });
    }
  }
}