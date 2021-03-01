using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BrandChallenge.Configuration;

namespace BrandChallenge.Web.Host.Startup
{
    [DependsOn(
       typeof(BrandChallengeWebCoreModule))]
    public class BrandChallengeWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BrandChallengeWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BrandChallengeWebHostModule).GetAssembly());
        }
    }
}
