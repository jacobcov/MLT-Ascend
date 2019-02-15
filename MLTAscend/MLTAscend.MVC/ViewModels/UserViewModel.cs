using MLTAscend.Data.Helpers;
using MLTAscend.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = MLTAscend.Domain.Models;
using dmt = MLTAscend.Domain.DataModels;
using MLTAscend.MVC.Models;

namespace MLTAscend.MVC.ViewModels
{
  public class UserViewModel
  {
    public List<dom.User> GetUsers()
    {
      var uh = new UserHelper();
      return uh.GetUsers();
    }

    internal bool SignUp(string name, string username, string password)
    {
      var uh = new UserHelper();

      var usr = new dom.User()
      {
        Name = name,
        Username = username,
        Password = password
      };

      return uh.SetUser(usr);
    }

    internal List<dom.Prediction> GetPredictions()
    {
      var ph = new PredictionHelper();
      return ph.GetPredictions();
    }

    internal bool CreateStockData(Symbol ticker)
    {
      var ph = new PredictionHelper();

      var stockData = new dmt.StockData()
      {
        timestamp = ticker.Date,
        open = (float)ticker.Open,
        high = (float)ticker.High,
        low = (float)ticker.Low,
        close = (float)ticker.Close,
        volume = ticker.Volume
      };

      var prediction = PredictionModelHelper.RunAllPredictions(stockData);
      prediction.CompanyName = ticker.CompanyName;
      prediction.Ticker = ticker.Ticker;
            
      return ph.SetPrediction(prediction, "fred");
    }
  }
}
