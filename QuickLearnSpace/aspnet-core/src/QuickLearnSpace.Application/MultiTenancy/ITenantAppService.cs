using Abp.Application.Services;
using Abp.Application.Services.Dto;
using QuickLearnSpace.MultiTenancy.Dto;

namespace QuickLearnSpace.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

