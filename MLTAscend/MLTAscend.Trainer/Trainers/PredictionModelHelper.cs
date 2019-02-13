using Microsoft.ML;
using Microsoft.ML.Core.Data;
using Microsoft.ML.Data;
using MLTAscend.Trainer.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MLTAscend.Trainer.Trainers
{
   public static class PredictionModelHelper
   {
      public static void TrainAndSaveModel(MLContext mlContext, string dataPath, string outputModelPath = "prediction_model.zip")
      {
         if (File.Exists(outputModelPath))
         {
            File.Delete(outputModelPath);
         }
         CreatePredictionModelUsingPipeline(mlContext, dataPath, outputModelPath);
      }

      public static void CreatePredictionModelUsingPipeline(MLContext mlContext, string dataPath, string outputModelPath)
      {
         var trainingDataView = mlContext.Data.ReadFromTextFile<StockData>(path: dataPath, hasHeader: true, separatorChar: ',');

         var trainer = mlContext.Regression.Trainers.FastTreeTweedie();

         var trainingPipeline = mlContext.Transforms.Concatenate(outputColumnName: DefaultColumnNames.Features, inputColumnNames: new string[] { "open", "high", "low", "close", "volume" })
               .Append(mlContext.Transforms.CopyColumns(outputColumnName: DefaultColumnNames.Label, inputColumnName: "next"))
               .Append(trainer);

         // Train the model
         var model = trainingPipeline.Fit(trainingDataView);

         // Save the model for later comsumption from end-user apps
         using (var file = File.OpenWrite(outputModelPath))
            model.SaveTo(mlContext, file);
      }

      public static PredictionResult RunPrediction(MLContext mlContext, StockData input, string outputModelPath = "prediction_model.zip")
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
