using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLTAscend.MVC.Models
{
  public class Ticker
  {
    [Required]
    [MaxLength(5, ErrorMessage = "Must be less than 5 characters")]
    public string Symbol { get; set; }
  }
}
