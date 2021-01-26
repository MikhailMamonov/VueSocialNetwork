using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VueJSSocialNetwork.Data.Entities;

namespace VueJSSocialNetwork.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //builder
            //    .HasMany(p => p.Comments)
            //    .WithOne(c => c.Post)
            //    .HasForeignKey(c => c.PostId);
        }
    }
}
