using System;
using GraphQL.Types;

namespace mrss.api.models
{
  public class PortfolioSchema : Schema
  {
    public PortfolioSchema(IServiceProvider provider) : base(provider)
    {
      Query = new RootQuery();
    }
  }
}