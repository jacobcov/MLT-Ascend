using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using dom = MLTAscend.Domain.Models;
using dat = MLTAscend.Data.Helpers;

namespace MLTAscend.Tests.UnitTests
{
   [Collection("SQL DB Tests")]
   public class UserHelperTests
   {
      private dom.User sut;
      private dom.User ExistUser;
      public dat.UserHelper UserHelper { get; set; }
      public string Ticker = "ryry";

      public UserHelperTests()
      {
         ExistUser = new dom.User()
         {
            Name = "fred",
            Username = "belottef",
            Password = "peoples"
         };

         UserHelper = new dat.UserHelper();
      }

      [Fact]
      public void Test_SetUser_Fail()
      {
         Assert.False(UserHelper.SetUser(ExistUser));
      }

      [Fact]
      public void Test_GetUserByUsername()
      {
         var actual = UserHelper.GetUserByUsername(ExistUser.Username);

         Assert.True(actual.Username == ExistUser.Username);
      }

      [Fact]
      public void Test_GetUserPredictions()
      {
         var actual = UserHelper.GetUserPredictions(ExistUser.Username);

         Assert.True(actual.Count > 0);
         Assert.True(actual[0].Ticker == "ryry");
      }

      [Fact]
      public void Test_GetUsers()
      {
         var actual = UserHelper.GetUsers();

         Assert.True(actual.Count > 0);
         Assert.True(actual[1].Username == ExistUser.Username);
      }

      [Fact]
      public void Test_GetAnonymousPredictions()
      {
         var actual = UserHelper.GetAnonymousPredictions();

         Assert.True(actual[0].Ticker == Ticker);
      }
   }
}
