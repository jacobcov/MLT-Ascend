using System;
using System.Collections.Generic;
using System.Text;
using dom = MLTAscend.Domain.Models;
using System.Linq;

namespace MLTAscend.Data.Helpers
{
    public class UserHelper
    {
        private static MLTAscendDbContext _db = new MLTAscendDbContext();

        public dom.User GetUserByUsername(string username)
        {
            return _db.Users.FirstOrDefault(m => m.Username == username);
        }

        public bool SetUser(dom.User user)
        {
            user.CreationDate = DateTime.Now;
            _db.Users.Add(user);
            return _db.SaveChanges() > 0;
        }
    }
}
