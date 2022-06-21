using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.LogisticsDetails;

namespace Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int LogisticsUserId { get; set; }
        public virtual LogisticsDetail LogisticsDetail { get; set; }

        public User()
        {
            Id = 1;
            Name = "Joe Cp";
            Email = "user@gmail.com";
        }
    }
}