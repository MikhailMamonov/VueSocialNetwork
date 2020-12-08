using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueJSSocialNetwork.Data.Entities
{
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.MaxInterestLength)]
        [MinLength(DataConstants.MinInterestLength)]
        public string Tag { get; set; }

        public ICollection<UserInterest> Users { get; set; } = new List<UserInterest>();
    }
}
