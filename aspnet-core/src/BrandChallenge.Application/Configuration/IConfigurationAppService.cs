using System.Threading.Tasks;
using BrandChallenge.Configuration.Dto;

namespace BrandChallenge.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
