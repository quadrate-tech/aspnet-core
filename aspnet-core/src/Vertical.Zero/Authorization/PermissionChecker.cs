using Abp.Authorization;
using Vertical.Authorization.Roles;
using Vertical.Authorization.Users;

namespace Vertical.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
