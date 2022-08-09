using Abp.Application.Services;
using IdVerificationService.MultiTenancy.Dto;

namespace IdVerificationService.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

