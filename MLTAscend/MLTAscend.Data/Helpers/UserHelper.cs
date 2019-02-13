using System;
using System.Collections.Generic;
using System.Text;
using dom = MLTAscend.Domain.Models;
using System.Linq;

namespace MLTAscend.Data.Helpers
{
    public class UserHelper
    {
        public MLTAscendDbContext ExtContext { get; set; }
        public InMemoryDbContext IntContext { get; set; }


        public UserHelper()
        {
            ExtContext = new MLTAscendDbContext(MLTAscendDbContext.Configuration);
            IntContext = null;
        }

        public UserHelper(InMemoryDbContext context)
        {
            IntContext = context;
            ExtContext = null;
        }

        public dom.User GetUserByUsername(string username)
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.Users.FirstOrDefault(m => m.Username == username);
            }
            else
            {
                return IntContext.Users.FirstOrDefault(m => m.Username == username);
            }
        }

        public bool SetUser(dom.User user)
        {
            var checkuser = GetUserByUsername(user.Username);
            if (checkuser != null && checkuser.Username == user.Username)
            {
                return false;
            }
            else
            {
                user.CreationDate = DateTime.Now;
                if (ExtContext != null && IntContext == null)
                {
                    ExtContext.Users.Add(user);
                    return ExtContext.SaveChanges() > 0;
                }
                else
                {
                    IntContext.Users.Add(user);
                    return IntContext.SaveChanges() > 0;
                }
            }
        }

        public List<dom.Prediction> GetUserPredictions(string username)
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.Predictions.Where(m => m.User.Username == username).ToList();
            }
            else
            {
                return IntContext.Predictions.Where(m => m.User.Username == username).ToList();
            }
        }

        public List<dom.User> GetUsers()
        {
            if (ExtContext != null && IntContext == null)
            {
                return ExtContext.Users.ToList();
            }
            else
            {
                return IntContext.Users.ToList();
            }
        }
    }
}
