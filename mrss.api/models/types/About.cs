using GraphQL.Types;

namespace mrss.api.models.types
{
  public class About : ObjectGraphType<About>
  {
    public new string Name { get; set; }
    public string Version { get; set; }
    public About()
    {
      Field(p => p.Name).Description("Name of the app");
      Field(p => p.Version).Description("Version of the app");
    }
  }
}