using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using dom = MLTAscend.Domain.Models;
using System.Linq;


namespace MLTAscend.Data.Helpers
{
    class PredictionHelper
    {
        private static MLTAscendDbContext _db = new MLTAscendDbContext();

        public dom.Prediction GetPredictionByName(string name)
        {
            return _db.Predictions.FirstOrDefault(m => m.CompanyName == name);
        }

        public bool SetPrediction(dom.Prediction prediction)
        {
            _db.Predictions.Add(prediction);
            return _db.SaveChanges() > 0;
        }
    }
}
