using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BrandChallenge.EntityFrameworkCore
{
    public static class BrandChallengeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BrandChallengeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BrandChallengeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
