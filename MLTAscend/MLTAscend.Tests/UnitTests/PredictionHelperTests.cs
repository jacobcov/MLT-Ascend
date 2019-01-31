using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using dom = MLTAscend.Domain.Models;
using dat = MLTAscend.Data.Helpers;

namespace MLTAscend.Tests.UnitTests
{
    public class PredictionHelperTests
    {
        private dom.Prediction sut;
        private dom.User User;
        public dat.PredictionHelper PredictonHelper { get; set; }

        public PredictionHelperTests()
        {
            User = new dom.User()
            {
                Name = "fred",
                Username = "belottef",
                Password = "peoples",
                Id = 6
            };

            sut = new dom.Prediction()
            {
                CompanyName = "ryry's chicken and waffles",
                Ticker = "ryry",

            };

            //sut.User = User;

            PredictonHelper = new dat.PredictionHelper();
        }

        [Fact]
        public void Test_SetPrediction()
        {
            Assert.True(PredictonHelper.SetPrediction(sut));
        }

        [Fact]
        public void Test_GetPredictionByTicker()
        {
            var actual = PredictonHelper.GetPredictionByTicker(sut.Ticker);

            Assert.True(actual.Ticker == sut.Ticker);
        }
    }
}
