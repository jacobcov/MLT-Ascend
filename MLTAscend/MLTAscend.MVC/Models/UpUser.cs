using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLTAscend.MVC.Models
{
  public class UpUser
  {
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string Password { get; set; }

    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string Confirm { get; set; }
  }
}
