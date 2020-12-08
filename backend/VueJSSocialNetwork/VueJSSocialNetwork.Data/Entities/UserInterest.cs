using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueJSSocialNetwork.Data.Entities
{
    public class UserInterest
    {
        public int InterestId { get; set; }

        public Interest Interest { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
