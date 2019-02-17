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
