using Microsoft.ML;
using Microsoft.ML.Core.Data;
using MLTAscend.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MLTAscend.Domain.Helpers
{
   class PredictionModelHelper
   {
      public static PredictionResult TestPrediction(MLContext mlContext, StockData input, string outputModelPath = "prediction_model.zip")
      {
         Console.WriteLine("Testing Product Unit Sales Forecast model");

         // Read the model that has been previously saved by the method SaveModel

         ITransformer trainedModel;

         using (var stream = File.OpenRead(outputModelPath))
         {
            trainedModel = mlContext.Model.Load(stream);
         }

         var predictionEngine = trainedModel.CreatePredictionEngine<StockData, PredictionResult>(mlContext);

         Console.WriteLine("** Testing Product 1 **");



         // Build sample data
         StockData dataSample = new StockData()
         {
            open = 103.86F,
            high = 104.88F,
            low = 103.2445F,
            close = 104.27F,
            timestamp = "2019-01-09",
            volume = 32280840
         };
         //103.8600,104.8800,103.2445,104.2700,32280840
         // Predict the nextperiod/month forecast to the one provided

         PredictionResult prediction = predictionEngine.Predict(input);
         Console.WriteLine($"Product: {dataSample.open}, date: {"2019-01-10"}, yesterday's high: {dataSample.high} - Real value (units): 103.7500, Forecast Prediction (units): {prediction.Score}");
         Console.WriteLine("done");
         return prediction;
      }
   }
}
