using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BrandChallenge.Configuration.Dto;

namespace BrandChallenge.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BrandChallengeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
