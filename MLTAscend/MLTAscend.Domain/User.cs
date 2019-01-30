using System;
using System.Collections.Generic;
using System.Text;

namespace MLTAscend.Domain
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Prediction> Predictions { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
