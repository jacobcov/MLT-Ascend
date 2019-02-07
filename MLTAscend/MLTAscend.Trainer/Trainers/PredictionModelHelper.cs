using Microsoft.ML;
using MLTAscend.Trainer.Data;
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
         var trainingDataView = mlContext.Data.ReadFromTextFile<PredictionData>(dataPath, hasHeader: true, separatorChar: ',');
         var trainer = mlContext.Regression.Trainers.FastTreeTweedie("Label", "Features");
         var trainingPipeline = mlContext.Transforms.Concatenate(outputColumnName: "NumFeatures", inputColumnNames: ["date", "open", "high", "low", "close", "volume"]);
      }
   }
}
