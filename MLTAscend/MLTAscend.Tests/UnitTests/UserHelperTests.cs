using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using dom = MLTAscend.Domain.Models;
using dat = MLTAscend.Data.Helpers;

namespace MLTAscend.Tests.UnitTests
{
    public class UserHelperTests
    {
        private dom.User sut;
        public dat.UserHelper UserHelper { get; set; }

        public UserHelperTests()
        {
            sut = new dom.User()
            {
                Name = "fred",
                Username = "belottef",
                Password = "peoples"
            };

            UserHelper = new dat.UserHelper();
        }

        [Fact]
        public void Test_SetUser()
        {
            Assert.True(UserHelper.SetUser(sut));
        }

        [Fact]
        public void Test_GetUserByUsername()
        {
            var actual = UserHelper.GetUserByUsername(sut.Username);

            Assert.True(actual.Username == sut.Username);
        }
    }
}
