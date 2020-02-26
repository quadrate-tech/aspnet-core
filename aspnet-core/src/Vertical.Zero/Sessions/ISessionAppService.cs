using System.Threading.Tasks;
using Abp.Application.Services;
using Vertical.Sessions.Dto;

namespace Vertical.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<CurrentLoginInfoOutput> GetCurrentLoginInformations();
    }
}
