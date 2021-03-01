using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace BrandChallenge.Authorization
{
    public class BrandChallengeAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Brands, L("Brands"));
            context.CreatePermission(PermissionNames.Pages_Challenges, L("Challenges"));
            context.CreatePermission(PermissionNames.Pages_Tricks, L("Tricks"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BrandChallengeConsts.LocalizationSourceName);
        }
    }
}
