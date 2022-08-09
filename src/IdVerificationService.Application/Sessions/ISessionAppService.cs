using System.Threading.Tasks;
using Abp.Application.Services;
using IdVerificationService.Sessions.Dto;

namespace IdVerificationService.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
