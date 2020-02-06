using Abp.Authorization;
using Abp.Localization;

namespace Vertical.Authorization
{
    public class VerticalAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //context.CreatePermission("Foo", L("Foo"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, VerticalConsts.LocalizationSourceName);
        }
    }
}
