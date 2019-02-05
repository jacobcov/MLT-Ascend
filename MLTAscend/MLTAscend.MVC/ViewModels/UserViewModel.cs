using MLTAscend.Data.Helpers;
using pdm = MLTAscend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLTAscend.MVC.ViewModels
{
  public class UserViewModel
  {
    public List<pdm.User> GetUsers()
    {
      var uh = new UserHelper();
      return uh.GetUsers();
    }

    internal bool SignUp(string name, string username, string password)
    {
      var uh = new UserHelper();

      var usr = new pdm.User()
      {
        Name = name,
        Username = username,
        Password = password
      };

      return uh.SetUser(usr);
    }
  }
}
