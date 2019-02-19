using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLTAscend.MVC.ViewModels;

namespace MLTAscend.MVC.Controllers
{
   public class HomeController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }

      public IActionResult LogIn()
      {
         return View("_LogIn");
      }

      public IActionResult SignUp()
      {
         return View("_SignUp");
      }

    public IActionResult History()
    {
      return RedirectToAction("User", "History");
    }

    public IActionResult Predict()
    {
      return View("../User/Predict");
    }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
