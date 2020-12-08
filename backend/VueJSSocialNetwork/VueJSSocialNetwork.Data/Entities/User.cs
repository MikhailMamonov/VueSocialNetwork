using Microsoft.AspNetCore.Identity;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VueJSSocialNetwork.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [Range(DataConstants.MinUserAge, DataConstants.MaxUserAge)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; } = false;


        public string PictureUrl { get; set; }
        public ICollection<UserInterest> Interests { get; set; } = new List<UserInterest>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<UserFriend> Friends { get; set; } = new List<UserFriend>();
    }
}
