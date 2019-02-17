using Microsoft.ML;
using Microsoft.ML.Core.Data;
using Microsoft.ML.Data;
using MLTAscend.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MLTAscend.Trainer.Trainers
{
   public static class PredictionModelTrainer
   {
      public static void TrainAndSaveModel(MLContext mlContext, string dataPath, string outputModelPath)
      {
         if (File.Exists(outputModelPath))
         {
            File.Delete(outputModelPath);
         }
         CreatePredictionModel(mlContext, dataPath, outputModelPath);
      }

      public static void CreatePredictionModel(MLContext mlContext, string dataPath, string outputModelPath)
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

      public static PredictionResult TestPrediction(MLContext mlContext, StockData input, string outputModelPath)
      {
         Console.WriteLine("Testing Forecast model");

         // Read the model that has been previously saved by the method SaveModel

         ITransformer trainedModel;

         using (var stream = File.OpenRead(outputModelPath))
         {
            trainedModel = mlContext.Model.Load(stream);
         }

         var predictionEngine = trainedModel.CreatePredictionEngine<StockData, PredictionResult>(mlContext);

         Console.WriteLine("** Testing Model **");

         // Predict the nextperiod/month forecast to the one provided

         PredictionResult prediction = predictionEngine.Predict(input);
         Console.WriteLine($"Product: {input.timestamp}, Forecast Prediction (high): {prediction.Score}");
         Console.WriteLine("done");
         return prediction;
      }
   }
}
