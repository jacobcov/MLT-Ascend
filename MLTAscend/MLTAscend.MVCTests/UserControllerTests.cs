using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using MLTAscend.MVC.Models;
using MLTAscend.MVC.Controllers;
using System.Threading.Tasks;
using System;

namespace MLTAscend.MVCTests
{
   [TestClass]
   public class UserControllerTests
   {
      public UserController Uc { get; set; }
      public InUser inUser { get; set; }

      public UserControllerTests()
      {
         Uc = new UserController();
      }

      [TestMethod]
      public void Test_GetTickerData()
      {
         var actual = Uc.GetTickerData(new Ticker());

         Assert.IsNotNull(actual);
      }

      [TestMethod]
      public void Test_GetTickerNews()
      {
         var actual = Uc.GetTickerNews(new Ticker());

         Assert.IsNotNull(actual);
      }

      [TestMethod]
      public void Test_GetCompanyName()
      {
         var actual = Uc.GetCompanyName(new Ticker());

         Assert.IsNotNull(actual);
      }
   }
}
