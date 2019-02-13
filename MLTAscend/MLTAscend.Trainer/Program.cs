using Microsoft.ML;
using MLTAscend.Trainer.DataModels;
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

         PredictionModelHelper.TrainAndSaveModel(mlContext, "../../../Trainers/daily_MSFT.stats.csv");
         PredictionModelHelper.RunPrediction(mlContext, dataSample);
         Console.ReadLine();
      }
   }
}
