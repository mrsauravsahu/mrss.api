using System;
using System.ComponentModel.DataAnnotations;

namespace mrss.types
{
  public class AppConfig
  {
    [Required]
    public string Name { get; set; }
  }
}
