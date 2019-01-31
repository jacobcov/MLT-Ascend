using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using dom = MLTAscend.Domain.Models;
using System.Linq;


namespace MLTAscend.Data.Helpers
{
    public class PredictionHelper
    {
        private static MLTAscendDbContext _db = new MLTAscendDbContext();

        public dom.Prediction GetPredictionByTicker(string ticker)
        {
            return _db.Predictions.FirstOrDefault(m => m.Ticker == ticker);
        }

        public bool SetPrediction(dom.Prediction prediction)
        {
            _db.Predictions.Add(prediction);
            return _db.SaveChanges() > 0;
        }
    }
}
