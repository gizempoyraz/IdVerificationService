using Abp.Authorization;
using IdVerificationService.Authorization.Roles;
using IdVerificationService.Authorization.Users;

namespace IdVerificationService.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
