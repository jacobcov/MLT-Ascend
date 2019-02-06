using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MLTAscend.MVC.Validators
{
  public class PasswordChars : ValidationAttribute
  {
    public override bool IsValid(object value)
    {
      var pass = value.ToString();

      if (pass == null)
      {
        return false;
      }
      
      return Regex.IsMatch(pass, "(^[0-9a-zA-z!@#$%^&*]+$)");
    }
  }
}
