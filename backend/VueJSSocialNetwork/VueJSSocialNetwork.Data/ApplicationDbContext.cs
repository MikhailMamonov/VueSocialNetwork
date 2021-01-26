using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using VueJSSocialNetwork.Data.Configurations;
using VueJSSocialNetwork.Data.Entities;

namespace VueJSSocialNetwork.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Post> Posts { get; set; }

        //public DbSet<Comment> Comments { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfiguration(new UserConfiguration());
            //builder.ApplyConfiguration(new PostConfiguration());

            builder.ApplyConfiguration(new UserInterestConfiguration());
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
