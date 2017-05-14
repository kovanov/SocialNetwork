using System.Data.Entity;

namespace SocialNetwork.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("SocialNetworkDb")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserRelation> Relations { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
    }
}
