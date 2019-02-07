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
      public DateTime date;

      [LoadColumn(1)]
      public decimal open;

      [LoadColumn(2)]
      public decimal high;

      [LoadColumn(3)]
      public decimal low;

      [LoadColumn(4)]
      public decimal close;

      [LoadColumn(5)]
      public int volume;

   }

   //public class ProductUnitPrediction
   //{
   //   public float Score;
   //}
}
