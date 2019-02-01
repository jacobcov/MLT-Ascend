using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLTAscend.MVC.Models
{
  public class InUser
  {
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string Password { get; set; }
  }
}
