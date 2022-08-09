using System.Threading.Tasks;
using Abp.Application.Services;
using IdVerificationService.Authorization.Accounts.Dto;

namespace IdVerificationService.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
