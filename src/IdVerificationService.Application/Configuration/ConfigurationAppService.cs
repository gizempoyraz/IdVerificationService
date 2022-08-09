using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using IdVerificationService.Configuration.Dto;

namespace IdVerificationService.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IdVerificationServiceAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
