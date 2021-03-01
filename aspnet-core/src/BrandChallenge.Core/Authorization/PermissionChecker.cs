using Abp.Authorization;
using BrandChallenge.Authorization.Roles;
using BrandChallenge.Authorization.Users;

namespace BrandChallenge.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
