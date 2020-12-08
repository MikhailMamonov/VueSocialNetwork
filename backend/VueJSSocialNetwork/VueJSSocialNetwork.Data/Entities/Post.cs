using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueJSSocialNetwork.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        [Range(0, int.MaxValue)]
        public int Likes { get; set; }

        public byte[] Photo { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

    }
}
