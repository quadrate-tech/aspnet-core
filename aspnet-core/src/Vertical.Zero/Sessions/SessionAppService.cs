using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Auditing;
using Vertical.Application.Services;
using Vertical.Sessions.Dto;

namespace Vertical.Sessions
{
    public class SessionAppService : VerticalZeroAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<CurrentLoginInfoOutput> GetCurrentLoginInformations()
        {
            var output = new CurrentLoginInfoOutput
            {
                Application = new ApplicationInfoDto
                {
                    Version = AppVersionHelper.Version,
                    ReleaseDate = AppVersionHelper.ReleaseDate,
                    Features = new Dictionary<string, bool>()
                }
            };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            if (AbpSession.UserId.HasValue)
            {
                output.User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync());
            }

            return output;
        }
    }
}
