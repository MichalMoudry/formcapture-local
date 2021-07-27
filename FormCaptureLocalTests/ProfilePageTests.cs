using Bunit;
using FormCaptureLocal;
using FormCaptureLocal.Pages.App.Profile;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Xunit;

namespace FormCaptureLocalTests
{
    public class ProfilePageTests
    {
        [Fact]
        public void EmptyNewPasswordFormTest()
        {
            using var context = new TestContext();
            //Add services to context
            context.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            context.Services.AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>();
            var profileComponent = context.RenderComponent<Profile>();
            //Get localizer
            var localizer = context.Services.GetService<IStringLocalizer<App>>();
            context.JSInterop.SetupVoid("displayToast", "password-error-toast");
            profileComponent.Find("#confirmButton").Click();
            profileComponent.Find("#errorMessage").TextContent.MarkupMatches($"{localizer["ProfilePageEmptyUpdatePasswordFormErrorMessage"]}.");
        }
    }
}