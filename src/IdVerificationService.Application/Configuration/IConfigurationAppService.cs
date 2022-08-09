using System.Threading.Tasks;
using IdVerificationService.Configuration.Dto;

namespace IdVerificationService.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
