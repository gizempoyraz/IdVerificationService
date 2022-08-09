using System.Collections.Generic;
using IdVerificationService.Roles.Dto;

namespace IdVerificationService.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}