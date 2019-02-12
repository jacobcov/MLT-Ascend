using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = MLTAscend.Domain.Models;

namespace MLTAscend.MVC.Models
{
  public class Log
  {
    public List<dom.Prediction> Predictions { get; set; }

    public Log()
    {
      Predictions = new List<dom.Prediction>();
    }
  }
}
