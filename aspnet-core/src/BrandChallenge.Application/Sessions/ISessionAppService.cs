using System.Threading.Tasks;
using Abp.Application.Services;
using BrandChallenge.Sessions.Dto;

namespace BrandChallenge.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
