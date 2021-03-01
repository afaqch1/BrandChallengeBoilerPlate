using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using BrandChallenge.Configuration;
using BrandChallenge.Web;

namespace BrandChallenge.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BrandChallengeDbContextFactory : IDesignTimeDbContextFactory<BrandChallengeDbContext>
    {
        public BrandChallengeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BrandChallengeDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BrandChallengeDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BrandChallengeConsts.ConnectionStringName));

            return new BrandChallengeDbContext(builder.Options);
        }
    }
}
