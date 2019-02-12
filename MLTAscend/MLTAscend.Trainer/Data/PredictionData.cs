using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace MLTAscend.Trainer.Data
{
   public class PredictionData
   {
      // date,open,high,low,close,volume
      private string _timestamp;
      [LoadColumn(0)]
      public string timestamp { get { return _timestamp; } set { _timestamp = value; } }

      private float _open;
      [LoadColumn(1)]
      public float open { get { return open; } set { open = value; } }

      private float _high;
      [LoadColumn(2)]
      public float high { get { return _high; } set { _high = value; } }

      private float _low;
      [LoadColumn(3)]
      public float low { get { return _low; } set { _low = value; } }

      private float _close;
      [LoadColumn(4)]
      public float close { get { return _close; } set { _close = value; } }

      private float _volume;
      [LoadColumn(5)]
      public float volume { get { return _volume; } set { _volume = value; } }

      private float _next;
      [LoadColumn(6)]
      public float next { get { return _next; } set { _next = value; } }

   }
}
