using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BrandChallenge.Controllers
{
    public abstract class BrandChallengeControllerBase: AbpController
    {
        protected BrandChallengeControllerBase()
        {
            LocalizationSourceName = BrandChallengeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
