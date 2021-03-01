using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BrandChallenge.EntityFrameworkCore;
using BrandChallenge.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BrandChallenge.Web.Tests
{
    [DependsOn(
        typeof(BrandChallengeWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BrandChallengeWebTestModule : AbpModule
    {
        public BrandChallengeWebTestModule(BrandChallengeEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BrandChallengeWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BrandChallengeWebMvcModule).Assembly);
        }
    }
}