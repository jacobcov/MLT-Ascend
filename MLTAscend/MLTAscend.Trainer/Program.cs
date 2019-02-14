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
            open = 47F,
            high = 47.1339F,
            low = 46.2399F,
            close = 47.01F,
            timestamp = "2015-01-26",
            volume = 42525530
         };
         var path = "../../../PredictionModels/OneDayPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/OneDayData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../PredictionModels/OneWeekPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/OneWeekData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../PredictionModels/OneMonthPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/OneMonthData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../PredictionModels/ThreeMonthPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/ThreeMonthData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         path = "../../../PredictionModels/OneYearPred_model.zip";
         PredictionModelTrainer.TrainAndSaveModel(mlContext, "../../../Data/OneYearData.csv", path);
         PredictionModelTrainer.TestPrediction(mlContext, dataSample, path);

         Console.ReadLine();
      }
   }
}
