using System.Threading.Tasks;
using Abp.Application.Services;
using BrandChallenge.Authorization.Accounts.Dto;

namespace BrandChallenge.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
