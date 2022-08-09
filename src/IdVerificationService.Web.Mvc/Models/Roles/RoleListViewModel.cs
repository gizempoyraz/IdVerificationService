using System.Collections.Generic;
using IdVerificationService.Roles.Dto;

namespace IdVerificationService.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
