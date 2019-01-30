using System;
using System.Collections.Generic;
using System.Text;

namespace MLTAscend.Domain
{
    public class Prediction
    {
        public string CompanyName { get; set; }
        public DateTime CreationDate { get; set; }

        public double OneWeekPred { get; set; }
        public double OneMonthPred { get; set; }
        public double ThreeMonthPred { get; set; }
        public double SixMonthPred { get; set; }
        public double OneYearPred { get; set; }
        public double TwoYearPred { get; set; }
        public double FiveYearPred { get; set; }
    }
}
