using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace mrss.api.Controllers
{
  [ApiController]
  [Route("")]
  public class RootController : ControllerBase
  {
    private readonly ILogger<RootController> _logger;

    public RootController(ILogger<RootController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public object Get()
    {
      return new
      {
        Data = new { Version = "v0.0.1" }
      };
    }
  }
}
