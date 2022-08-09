using System.Threading.Tasks;
using Abp.ObjectMapping;
using IdVerificationService.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace IdVerificationService.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : IdVerificationServiceViewComponent
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IObjectMapper _objectMapper;

        public TenantChangeViewComponent(ISessionAppService sessionAppService, IObjectMapper objectMapper)
        {
            _sessionAppService = sessionAppService;
            _objectMapper = objectMapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
            var model = _objectMapper.Map<TenantChangeViewModel>(loginInfo);
            return View(model);
        }
    }
}
