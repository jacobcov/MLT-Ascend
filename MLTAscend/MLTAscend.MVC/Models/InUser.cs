using MLTAscend.MVC.Validators;
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
    [MinLength(4, ErrorMessage = "Must be at least 4 characters long")]
    [MaxLength(50, ErrorMessage = "Must be less than 50 characters")]
    public string Username { get; set; }

    [Required]
    [MinLength(4, ErrorMessage = "Must be at least 4 characters long")]
    [MaxLength(50, ErrorMessage = "Must be less than 50 characters")]
    [PasswordChars(ErrorMessage = "Must only contain valid characters")]
    public string Password { get; set; }
  }
}
