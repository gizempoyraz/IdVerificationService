using System.Collections.Generic;
using IdVerificationService.Roles.Dto;

namespace IdVerificationService.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
