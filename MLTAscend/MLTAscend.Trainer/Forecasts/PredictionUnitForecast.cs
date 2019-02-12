using System;
using System.Collections.Generic;
using System.Text;

namespace MLTAscend.Trainer.Forecasts
{
   public class PredictionUnitForecast
   {
      private float _Score;
      public float Score { get { return _Score; } set { _Score = value; } }
   }
}
