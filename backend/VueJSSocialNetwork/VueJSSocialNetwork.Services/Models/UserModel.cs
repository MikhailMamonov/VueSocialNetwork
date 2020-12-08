using System;
using System.Collections.Generic;
using System.Text;
using VueJSSocialNetwork.Common.Mapping;
using VueJSSocialNetwork.Data.Entities;

namespace VueJSSocialNetwork.Services.Models
{
        public class UserModel : IMapFrom<User>
        {
            public string Email { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Username { get; set; }

            public int Age { get; set; }
        }
}
