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
            open = 103.86F,
            high = 104.88F,
            low = 103.2445F,
            close = 104.27F,
            timestamp = "2019-01-09",
            volume = 32280840
         };
         var path = "../../../PredictionModels/OneDayPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/daily_MSFT.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../PredictionModels/OneWeekPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/daily_MSFT.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../PredictionModels/OneMonthPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/daily_MSFT.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../PredictionModels/ThreeMonthPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/daily_MSFT.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../PredictionModels/OneYearPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/daily_MSFT.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         Console.ReadLine();
      }
   }
}
