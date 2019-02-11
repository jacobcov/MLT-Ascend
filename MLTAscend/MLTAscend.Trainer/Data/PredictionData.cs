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
      public float open;

      [LoadColumn(2)]
      public float high;

      [LoadColumn(3)]
      public float low;

      [LoadColumn(4)]
      public float close;

      [LoadColumn(5)]
      public float volume;

      [LoadColumn(6)]
      public float next;
   }

   //public class ProductUnitPrediction
   //{
   //   public float Score;
   //}
}
