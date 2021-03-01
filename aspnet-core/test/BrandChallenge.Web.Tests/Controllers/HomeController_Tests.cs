using System.Threading.Tasks;
using BrandChallenge.Models.TokenAuth;
using BrandChallenge.Web.Controllers;
using Shouldly;
using Xunit;

namespace BrandChallenge.Web.Tests.Controllers
{
    public class HomeController_Tests: BrandChallengeWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}