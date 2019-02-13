using Microsoft.ML;
using Microsoft.ML.Core.Data;
using MLTAscend.Domain.DataModels;
using MLTAscend.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MLTAscend.Domain.Helpers
{
   public static class PredictionModelHelper
   {
      public static MLContext mlContext { get; set; } = new MLContext();


      public static Prediction RunAllPredictions(StockData input)
      {
         var p = new Prediction();

         p.OneDayPred = RunPrediction(input, "../../../../MLTAscend.Trainer/PredictionModels/OneDayPred_model.zip").Score;
         p.OneWeekPred = RunPrediction(input, "../../../../MLTAscend.Trainer/PredictionModels/OneWeekPred_model.zip").Score;
         p.OneMonthPred = RunPrediction(input, "../../../../MLTAscend.Trainer/PredictionModels/OneMonthPred_model.zip").Score;
         p.ThreeMonthPred = RunPrediction(input, "../../../../MLTAscend.Trainer/PredictionModels/ThreeMonthPred_model.zip").Score;
         p.OneYearPred = RunPrediction(input, "../../../../MLTAscend.Trainer/PredictionModels/OneYearPred_model.zip").Score;

         return p;
      }

      private static PredictionResult RunPrediction(StockData input, string modelPath)
      {

         // Read the model that has been previously saved by the method SaveModel
         ITransformer trainedModel;

         using (var stream = File.OpenRead(modelPath))
         {
            trainedModel = mlContext.Model.Load(stream);
         }

         var predictionEngine = trainedModel.CreatePredictionEngine<StockData, PredictionResult>(mlContext);

         // Predict the nextperiod/month forecast to the one provided

         return predictionEngine.Predict(input);
      }
   }
}
