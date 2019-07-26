using System.Threading.Tasks;
using QuickLearnSpace.Configuration.Dto;

namespace QuickLearnSpace.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
