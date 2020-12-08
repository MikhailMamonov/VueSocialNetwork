using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using VueJSSocialNetwork.Data.Configurations;
using VueJSSocialNetwork.Data.Entities;

namespace VueJSSocialNetwork.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> _options) : base(_options)
        {
        }

        //public DbSet<Customer> Customers { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<UserFriend> UserFriend { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new UserInterestConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (options == null)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-QMSUOKD\\SQLEXPRESS;AttachDbFileName=D:\\BookApi\\backend\\SocialNetwork.mdf; Database=SocialNetwork;Trusted_Connection=Yes;");
        //    }
        //}

    }
}
