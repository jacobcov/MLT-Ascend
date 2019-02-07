using System;
using System.Collections.Generic;
using System.Text;

namespace MLTAscend.Domain.Models
{
    public class Prediction
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Ticker { get; set; }
        public DateTime CreationDate { get; set; }

        public User User { get; set; }

        public double OneDayPred { get; set; }
        public double OneWeekPred { get; set; }
        public double OneMonthPred { get; set; }
        public double ThreeMonthPred { get; set; }
        public double SixMonthPred { get; set; }
        public double OneYearPred { get; set; }
        public double TwoYearPred { get; set; }
        public double FiveYearPred { get; set; }

        public Prediction()
        {
            User = new User();
        }
    }
}
