using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MLTAscend.MVC.Controllers
{
  public class UserController : Controller
  {
    public IActionResult LogIn()
    {
      return View("_LogIn");
    }

    public IActionResult SignUp()
    {
      return View("_SignUp");
    }
  }
}