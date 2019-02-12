using Microsoft.ML;
using Microsoft.ML.Core.Data;
using Microsoft.ML.Data;
using MLTAscend.Trainer.Data;
using MLTAscend.Trainer.Forecasts;
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
         var trainingDataView = mlContext.Data.ReadFromTextFile<PredictionData>(path: dataPath, hasHeader: true, separatorChar: ',');

         var trainer = mlContext.Regression.Trainers.FastTreeTweedie();

         var trainingPipeline = mlContext.Transforms.Concatenate(outputColumnName: DefaultColumnNames.Features, inputColumnNames: new string[] { nameof(PredictionData.open), nameof(PredictionData.high), nameof(PredictionData.low), nameof(PredictionData.close), nameof(PredictionData.volume) })
              // .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "CatFeatures", inputColumnName: nameof(PredictionData.timestamp)))
              //     .Append(mlContext.Transforms.Concatenate(outputColumnName: DefaultColumnNames.Features, inputColumnNames: new string[] { "CatFeatures", "NumFeatures" }))
              .Append(mlContext.Transforms.CopyColumns(outputColumnName: DefaultColumnNames.Label, inputColumnName: nameof(PredictionData.next)))
            .Append(trainer);

         //Console.WriteLine("=============== Cross-validating to get model's accuracy metrics ===============");
         //var crossValidationResults = mlContext.Regression.CrossValidate(data: trainingDataView, estimator: trainingPipeline, numFolds: 6, labelColumn: DefaultColumnNames.Label);
         Console.WriteLine();
         //ConsoleHelper.PrintRegressionFoldsAverageMetrics(trainer.ToString(), crossValidationResults);

         // Train the model
         var model = trainingPipeline.Fit(trainingDataView);

         // Save the model for later comsumption from end-user apps
         using (var file = File.OpenWrite(outputModelPath))
            model.SaveTo(mlContext, file);
      }

      public static void TestPrediction(MLContext mlContext, string outputModelPath = "prediction_model.zip")
      {
         Console.WriteLine("Testing Product Unit Sales Forecast model");

         // Read the model that has been previously saved by the method SaveModel

         ITransformer trainedModel;

         using (var stream = File.OpenRead(outputModelPath))
         {
            trainedModel = mlContext.Model.Load(stream);
         }

         var predictionEngine = trainedModel.CreatePredictionEngine<PredictionData, PredictionUnitForecast>(mlContext);
         var pE = trainedModel.CreatePredictionEngine<PredictionData, PredictionUnitForecast>(mlContext);

         Console.WriteLine("** Testing Product 1 **");



         // Build sample data
         PredictionData dataSample = new PredictionData()
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

         PredictionUnitForecast prediction = predictionEngine.Predict(dataSample);
         PredictionUnitForecast p2 = pE.Predict(dataSample);
         Console.WriteLine($"Product: {dataSample.open}, date: {"2019-01-10"}, yesterday's high: {dataSample.high} - Real value (units): 103.7500, Forecast Prediction (units): {prediction.Score} , {p2.Score}");
         Console.WriteLine("done");
         Console.ReadLine();
      }
   }
}
