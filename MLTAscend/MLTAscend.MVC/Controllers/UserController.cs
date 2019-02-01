using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dom = MLTAscend.Domain.Models;

namespace MLTAscend.MVC.Controllers
{
  public class UserController : Controller
  {
    //[Route("Home/LogIn")]
    public IActionResult LogIn(User signIn)
    {
      if (ModelState.IsValid)
      {
        var uvm = new UserViewModel();
        var user = uvm.GetUsers().FirstOrDefault(u => u.Username == signIn.Username);

        if (user != null && signIn.Password == user.Password)
        {
          HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));

          return RedirectToAction("Start", "Order");
        };
      }
      return RedirectToAction("SignUp", "Home");
    }

    public IActionResult SignUp()
    {
      return View("_SignUp");
    }
  }
}