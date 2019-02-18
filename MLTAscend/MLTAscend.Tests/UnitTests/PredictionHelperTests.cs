using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using dom = MLTAscend.Domain.Models;
using dat = MLTAscend.Data.Helpers;

namespace MLTAscend.Tests.UnitTests
{
    [Collection("DbHelperTests")]
    public class PredictionHelperTests
    {
        private dom.Prediction sut;
        private dom.User User;
        public dat.PredictionHelper PredictionHelper { get; set; }
        public dat.UserHelper UserHelper { get; set; }
        public dom.Prediction Pred;

        public PredictionHelperTests()
        {
            User = new dom.User()
            {
                Name = "anon",
                Username = "anonymous",
                Password = "password"
            };

            Pred = new dom.Prediction()
            {
                Ticker = "ryry"
            };

            sut = new dom.Prediction()
            {
                CompanyName = "ryry's chicken and waffles",
                Ticker = "ryry",

            };

            PredictionHelper = new dat.PredictionHelper(new Data.InMemoryDbContext());
            UserHelper = new dat.UserHelper(new Data.InMemoryDbContext());

            UserHelper.SetUser(User);
            PredictionHelper.SetPrediction(Pred, User.Username);
        }

        [Fact]
        public void Test_SetPrediction()
        {
            Assert.True(PredictionHelper.SetPrediction(sut, User.Username));
        }

        [Fact]
        public void Test_SetAnonymousPrediction()
        {
            Assert.True(PredictionHelper.SetAnonymousPrediction(sut));
        }

        [Fact]
        public void Test_GetPredictionByTicker()
        {
            var actual = PredictionHelper.GetPredictionByTicker(sut.Ticker);

            Assert.True(actual.Ticker == sut.Ticker);
        }

        [Fact]
        public void Test_GetPredictions()
        {
            var actual = PredictionHelper.GetPredictions();

            Assert.True(actual.Count > 0);
            Assert.True(actual[0].Ticker == sut.Ticker);
        }
    }
}
