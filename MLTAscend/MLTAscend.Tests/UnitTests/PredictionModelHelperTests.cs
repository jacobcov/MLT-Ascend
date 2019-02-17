using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ddm = MLTAscend.Domain.DataModels;
using dhp = MLTAscend.Domain.Helpers;

namespace MLTAscend.Tests.UnitTests
{
    public class PredictionModelHelperTests
    {
        public ddm.StockData sut { get; set; }

        public PredictionModelHelperTests()
        {
            sut = new ddm.StockData()
            {
                open = 200,
                high = 200,
                low = 200,
                close = 200,
                volume = 200
            };
        }

        [Fact]
        public void Test_RunAllPredictions()
        {
            var actual = dhp.PredictionModelHelper.RunAllPredictions(sut);

            Assert.True(actual.OneDayPred > 0);
            Assert.True(actual.OneWeekPred > 0);
            Assert.True(actual.OneMonthPred > 0);
            Assert.True(actual.ThreeMonthPred > 0);
            Assert.True(actual.OneYearPred > 0);
        }
    }
}
