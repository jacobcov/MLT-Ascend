using Microsoft.ML;
using MLTAscend.Domain.DataModels;
using MLTAscend.Trainer.Trainers;
using System;

namespace MLTAscend.Trainer
{
   static class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello World!");
         MLContext mlContext = new MLContext(seed: 1);

         StockData dataSample = new StockData()
         {
            open = 73.55F,
            high = 74.17F,
            low = 73.17F,
            close = 73.85F,
            timestamp = "2017-09-27",
            volume = 18934048
         };
         var path = "../../../../MLTAscend.MVC/wwwroot/PredictionModels/OneDayPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/OneDayData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../../MLTAscend.MVC/wwwroot/PredictionModels/OneWeekPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/OneWeekData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../../MLTAscend.MVC/wwwroot/PredictionModels/OneMonthPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/OneMonthData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../../MLTAscend.MVC/wwwroot/PredictionModels/ThreeMonthPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/ThreeMonthData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../../MLTAscend.MVC/wwwroot/PredictionModels/OneYearPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/OneYearData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);
         Console.ReadLine();
      }
   }
}
