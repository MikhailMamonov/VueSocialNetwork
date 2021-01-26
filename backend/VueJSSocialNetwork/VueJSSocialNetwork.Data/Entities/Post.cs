using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueJSSocialNetwork.Data.Entities
{
    public partial class Post
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        [Range(0, int.MaxValue)]
        public int Likes { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
        
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

    }
}
