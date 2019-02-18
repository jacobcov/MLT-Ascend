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
            return _db.Predictions.LastOrDefault(m => m.Ticker == ticker);
        }

        public bool SetPrediction(dom.Prediction prediction, string username)
        {
            var uh = new UserHelper();

            prediction.CreationDate = DateTime.Now;
            var usr = uh.GetUserByUsername(username);
            prediction.User = usr;

            var e = _db.Entry<dom.Prediction>(prediction).Entity;

            e.User = usr;
            _db.Predictions.Attach(e).State = EntityState.Added;

            return _db.SaveChanges() > 0;
        }

        public bool SetAnonymousPrediction(dom.Prediction prediction)
        {
            return SetPrediction(prediction, "anonymous");
        }

        public List<dom.Prediction> GetPredictions()
        {
            return _db.Predictions.ToList();
        }
    }
}
