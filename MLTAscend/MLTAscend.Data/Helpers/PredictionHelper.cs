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

        public dom.User GetUser(string username)
        {
            return _db.Users.FirstOrDefault(m => m.Username == username);
        }
    }
}
