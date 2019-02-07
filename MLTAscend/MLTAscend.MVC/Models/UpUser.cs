using MLTAscend.MVC.Validators;
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
    [MinLength(1, ErrorMessage = "Must have at least one character")]
    [MaxLength(50, ErrorMessage = "Must be less than 50 characters")]
    public string Name { get; set; }

    [Required]
    [MinLength(4, ErrorMessage = "Must be at least 4 characters long")]
    [MaxLength(50, ErrorMessage = "Must be less than 50 characters")]
    public string Username { get; set; }

    [Required]
    [MinLength(4, ErrorMessage = "Must be at least 4 characters long")]
    [MaxLength(50, ErrorMessage = "Must be less than 50 characters")]
    [PasswordAttribute(ErrorMessage = "Must only contain valid characters")]
    public string Password { get; set; }

    [Required(ErrorMessage ="The Password field is required.")]
    [MinLength(4, ErrorMessage = "Must be at least 4 characters long")]
    [MaxLength(50, ErrorMessage = "Must be less than 50 characters")]
    public string Confirm { get; set; }
  }
}
