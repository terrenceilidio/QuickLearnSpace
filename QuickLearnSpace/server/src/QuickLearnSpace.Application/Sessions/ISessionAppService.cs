using System.Threading.Tasks;
using Abp.Application.Services;
using QuickLearnSpace.Sessions.Dto;

namespace QuickLearnSpace.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
