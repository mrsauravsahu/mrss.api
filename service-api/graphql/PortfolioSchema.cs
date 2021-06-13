using System;
using GraphQL.Types;

namespace mrss.api.graphql
{
  public class PortfolioSchema : Schema
  {
    public PortfolioSchema(IServiceProvider provider, RootQuery rootQuery) : base(provider)
    {
      Query = rootQuery;
    }
  }
}