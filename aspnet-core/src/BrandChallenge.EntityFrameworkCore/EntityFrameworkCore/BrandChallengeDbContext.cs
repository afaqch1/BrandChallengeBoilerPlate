using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BrandChallenge.Authorization.Roles;
using BrandChallenge.Authorization.Users;
using BrandChallenge.MultiTenancy;
using BrandChallenge.Brands;
using BrandChallenge.Challenges;
using BrandChallenge.Tricks;
using System.Reflection;

namespace BrandChallenge.EntityFrameworkCore
{
    public class BrandChallengeDbContext : AbpZeroDbContext<Tenant, Role, User, BrandChallengeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<Trick> Tricks { get; set; }

        public BrandChallengeDbContext(DbContextOptions<BrandChallengeDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
