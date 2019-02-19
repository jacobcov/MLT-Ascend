using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using MLTAscend.MVC.Models;
using MLTAscend.MVC.Controllers;

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
      public void TestMethod1()
      {
         var actual = Uc.GetTickerData(new Ticker());

         Assert.IsNotNull(actual);
      }
   }
}
