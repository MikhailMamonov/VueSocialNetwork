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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            //builder
            //    .HasMany(u => u.Friends)
            //    .WithOne(uf => uf.User)
            //    .HasForeignKey(uf => uf.UserId);



            builder
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            //builder
            //    .HasMany(u => u.Comments)
            //    .WithOne(c => c.User)
            //    .HasForeignKey(c => c.UserId);

        }
    }
}
