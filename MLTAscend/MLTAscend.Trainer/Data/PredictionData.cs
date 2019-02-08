using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace MLTAscend.Trainer.Data
{
   public class PredictionData
   {
      // date,open,high,low,close,volume
      [LoadColumn(0)]
      public string timestamp;

      [LoadColumn(1)]
      public double open;

      [LoadColumn(2)]
      public double high;

      [LoadColumn(3)]
      public double low;

      [LoadColumn(4)]
      public double close;

      [LoadColumn(5)]
      public double volume;

   }

   //public class ProductUnitPrediction
   //{
   //   public float Score;
   //}
}
