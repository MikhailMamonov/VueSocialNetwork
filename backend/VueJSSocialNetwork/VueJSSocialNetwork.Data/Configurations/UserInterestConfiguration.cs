using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VueJSSocialNetwork.Data.Entities;

namespace VueJSSocialNetwork.Data.Configurations
{
    public class UserInterestConfiguration : IEntityTypeConfiguration<UserInterest>
    {
        public void Configure(EntityTypeBuilder<UserInterest> builder)
        {
            builder.HasKey(ui => new { ui.UserId, ui.InterestId });

            builder
                .HasOne(ui => ui.User)
                .WithMany(u => u.Interests)
                .HasForeignKey(ui => ui.UserId);

            builder
                .HasOne(ui => ui.Interest)
                .WithMany(i => i.Users)
                .HasForeignKey(ui => ui.InterestId);
        }
    }
}
