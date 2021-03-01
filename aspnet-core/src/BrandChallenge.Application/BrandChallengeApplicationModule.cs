using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BrandChallenge.Authorization;

namespace BrandChallenge
{
    [DependsOn(
        typeof(BrandChallengeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BrandChallengeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BrandChallengeAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BrandChallengeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
