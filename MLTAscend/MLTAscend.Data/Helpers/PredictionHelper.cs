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
        public MLTAscendDbContext ExtContext { get; set; }
        public InMemoryDbContext IntContext { get; set; }


        public PredictionHelper()
        {
            ExtContext = new MLTAscendDbContext(MLTAscendDbContext.Configuration);
            IntContext = null;
        }

        public PredictionHelper(InMemoryDbContext context)
        {
            IntContext = context;
            ExtContext = null;
        }

        public dom.Prediction GetPredictionByTicker(string ticker)
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.Predictions.LastOrDefault(m => m.Ticker == ticker);
            }
            else
            {
                return IntContext.Predictions.LastOrDefault(m => m.Ticker == ticker);
            }
        }

        public bool SetPrediction(dom.Prediction prediction, string username)
        {
            var uh = new UserHelper(new InMemoryDbContext());

            prediction.CreationDate = DateTime.Now;
            var usr = uh.GetUserByUsername(username);

            if (ExtContext != null && IntContext == null)
            {
                prediction.User = usr;
                var e = ExtContext.Entry<dom.Prediction>(prediction).Entity;

                e.User = usr;
                ExtContext.Predictions.Attach(e).State = EntityState.Added;

                return ExtContext.SaveChanges() > 0;
            }
            else
            {
                dom.User User = new dom.User()
                {
                    Name = "jim",
                    Username = "bob",
                    Password = "jon"
                };
                prediction.User = User;
                IntContext.Predictions.Add(prediction);
                return IntContext.SaveChanges() > 0;
            }
        }

        public List<dom.Prediction> GetPredictions()
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.Predictions.ToList();
            }
            else
            {
                return IntContext.Predictions.ToList();
            }
        }
    }
}
