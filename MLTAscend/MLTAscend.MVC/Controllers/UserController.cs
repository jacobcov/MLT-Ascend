using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLTAscend.MVC.Models;
using MLTAscend.MVC.ViewModels;
using Newtonsoft.Json;
using dom = MLTAscend.Domain.Models;

namespace MLTAscend.MVC.Controllers
{
  public class UserController : Controller
  {
    // add route
    public IActionResult LogIn(InUser signIn)
    {
      if (ModelState.IsValid)
      {
        var uvm = new UserViewModel();
        var user = uvm.GetUsers().FirstOrDefault(u => u.Username == signIn.Username);

        if (user != null && signIn.Password == user.Password)
        {
          // add to session

          return View("LoggedIn");
        }
      }
      return View("../Home/_LogIn");
    }

    // add route
    public IActionResult SignUp(UpUser signUp)
    {
      if (ModelState.IsValid)
      {
        var uvm = new UserViewModel();
        var users = uvm.GetUsers();

        if (!users.Exists(u => u.Username == signUp.Username) && signUp.Password == signUp.Confirm)
        {
          uvm.SignUp(signUp.Name, signUp.Username, signUp.Password);

          var user = uvm.GetUsers().Find(u => u.Username == signUp.Username);
          // add to session

          return View("LoggedIn");
        }
      }
      return View("../Home/_SignUp");
    }

    [Route("[controller]/Logs/{sort?}")]
    public IActionResult Logs(string sort)
    {
      var uvm = new UserViewModel();

      var log = new Log()
      {
        Predictions = uvm.GetPredictions()
      };
      
      if(TempData["inverse"] == null)
      {
        TempData["inverse"] = false;
      }

      var inverse = (bool)TempData["inverse"];

      switch (sort)
      {
        case "CreationDate":
          if (inverse)
          {
            log.Predictions.Sort((x, y) => ((DateTime)y.GetType().GetProperty(sort).GetValue(y)).CompareTo((DateTime)x.GetType().GetProperty(sort).GetValue(x)));
          }
          else
          {
            log.Predictions.Sort((y, x) => ((DateTime)y.GetType().GetProperty(sort).GetValue(y)).CompareTo((DateTime)x.GetType().GetProperty(sort).GetValue(x)));
          }
          TempData["inverse"] = !inverse;
          break;
        case "CompanyName":
        case "Ticker":
          if (inverse)
          {
            log.Predictions.Sort((x, y) => ((string)y.GetType().GetProperty(sort).GetValue(y)).CompareTo((string)x.GetType().GetProperty(sort).GetValue(x)));
          }
          else
          {
            log.Predictions.Sort((y, x) => ((string)y.GetType().GetProperty(sort).GetValue(y)).CompareTo((string)x.GetType().GetProperty(sort).GetValue(x)));
          }
          TempData["inverse"] = !inverse;
          break;
        case "OneDayPred":
        case "OneWeekPred":
        case "OneMonthPred":
        case "ThreeMonthPred":
        case "OneYearPred":
          if (inverse)
          {
            log.Predictions.Sort((x, y) => ((double)y.GetType().GetProperty(sort).GetValue(y)).CompareTo((double)x.GetType().GetProperty(sort).GetValue(x)));
          }
          else
          {
            log.Predictions.Sort((y, x) => ((double)y.GetType().GetProperty(sort).GetValue(y)).CompareTo((double)x.GetType().GetProperty(sort).GetValue(x)));
          }
          TempData["inverse"] = !inverse;
          break;
        default:
          log.Predictions.Sort((x, y) => y.CreationDate.CompareTo(x.CreationDate));
          TempData["inverse"] = !inverse;
          break;
      }
      
      return View("../User/Logs", log);
    }
  }
}