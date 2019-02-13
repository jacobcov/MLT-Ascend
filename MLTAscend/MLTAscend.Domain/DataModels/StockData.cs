using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace MLTAscend.Domain.DataModels
{
   public class StockData
   {
      // date,open,high,low,close,volume, next
      [LoadColumn(0)]
      public string timestamp { get; set; }

      [LoadColumn(1)]
      public float open { get; set; }

      [LoadColumn(2)]
      public float high { get; set; }

      [LoadColumn(3)]
      public float low { get; set; }

      [LoadColumn(4)]
      public float close { get; set; }

      [LoadColumn(5)]
      public float volume { get; set; }

      [LoadColumn(6)]
      public float next { get; set; }

   }
}
