using MLTAscend.Domain.DataModels;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MLTAscend.Trainer.Trainers;
using System.IO;

namespace MLTAscend.Tests.UnitTests
{
    public class PredictionModelTrainerTests
    {
        public StockData dat { get; set; }
        public MLContext mlc { get; set; }
        public string OutPathTP { get; set; }
        public string DatPath { get; set; }
        public string OutPathTasm { get; set; }
        public string OutModelPath { get; set; }

        public PredictionModelTrainerTests()
        {
            dat = new StockData()
            {
                open = 103.86F,
                high = 104.88F,
                low = 103.2445F,
                close = 104.27F,
                timestamp = "2019-01-09",
                volume = 32280840
            };

            mlc = new MLContext();
            OutPathTP = "../../../../MLTAscend.Trainer/PredictionModels/OneDayPred_model.zip";
            DatPath = "../../../../MLTAscend.Trainer/Data/daily_MSFT.csv";
            OutPathTasm = "../../../../MLTAscend.Trainer/PredictionModels/OneDayPred_modeltasm.zip";
        }



        [Fact]
        public void Test_TrainAndSaveModel()
        {
            PredictionModelTrainer.TrainAndSaveModel(mlc, DatPath, OutPathTasm);

            Assert.True(File.Exists(OutPathTasm));
        }

        [Fact]
        public void Test_TestPrediction()
        {
            Assert.True(PredictionModelTrainer.TestPrediction(mlc, dat, OutPathTP).Score > 0);
        }
    }
}

