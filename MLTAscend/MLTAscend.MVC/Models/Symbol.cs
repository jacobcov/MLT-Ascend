using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLTAscend.MVC.Models
{
  public class Symbol
  {
    public string Date { get; set; }
    public double Open { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }
    public int Volume { get; set; }
  }
}
