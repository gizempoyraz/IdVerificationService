using System.Threading.Tasks;
using IdVerificationService.Models.TokenAuth;
using IdVerificationService.Web.Controllers;
using Shouldly;
using Xunit;

namespace IdVerificationService.Web.Tests.Controllers
{
    public class HomeController_Tests: IdVerificationServiceWebTestBase
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