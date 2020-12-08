using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VueJSSocialNetwork.Data.Entities;

namespace VueJSSocialNetwork.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Friends)
                .WithOne(uf => uf.User)
                .HasForeignKey(uf => uf.UserId);

        }
    }
}