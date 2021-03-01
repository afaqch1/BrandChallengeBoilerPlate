using Abp.Application.Services;
using BrandChallenge.MultiTenancy.Dto;

namespace BrandChallenge.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

