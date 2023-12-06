using Microsoft.EntityFrameworkCore;
using MyTriApp.Data.Entities;
using MyTriApp.Data.Mappings;
using MyTriApp.Secrets;

namespace MyTriApp.Data
{
    public class MyTriAppDbContext : DbContext, IMyTriAppDbContext
    {
        private readonly SecretsProvider _secretsProvider;

        public DbSet<StravaAccessToken> StravaAccessTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Lap> Lap { get; set; }

        public MyTriAppDbContext(DbContextOptions<MyTriAppDbContext> options, SecretsProvider secretsProvider) : base(options) 
        { 
            _secretsProvider = secretsProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _secretsProvider.GetSecretAsync("DbConnectionString").Result;
            Console.WriteLine(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMappings());
        }

    }
}
