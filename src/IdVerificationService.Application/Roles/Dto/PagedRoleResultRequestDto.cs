using Abp.Application.Services.Dto;

namespace IdVerificationService.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

