using MLTAscend.Data.Helpers;
using MLTAscend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLTAscend.MVC.ViewModels
{
  public class UserViewModel
  {
    public List<User> GetUsers()
    {
      var uh = new UserHelper();
      return uh.GetUsers();
    }
  }
}
