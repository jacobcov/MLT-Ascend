using System;
using System.Collections.Generic;
using System.Text;

namespace MLTAscend.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
