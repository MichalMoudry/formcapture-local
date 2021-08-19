using Bunit;
using FormCaptureLocal;
using FormCaptureLocal.Pages.App.Profile;
using FormCaptureLocal.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Xunit;

namespace FormCaptureLocalTests
{
    /// <summary>
    /// Profile page tests.
    /// </summary>
    public class ProfilePageTests
    {
        /// <summary>
        /// Test if empty password error message is displayed correctly.
        /// </summary>
        [Fact]
        public void EmptyNewPasswordFormTest()
        {
            using var context = new TestContext();
            //Add services to context
            _ = context.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            _ = context.Services.AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>()
                            .AddSingleton<DataAccess>()
                            .AddSingleton<AlertService>();
            var profileComponent = context.RenderComponent<Profile>();
            //Get localizer
            var localizer = context.Services.GetService<IStringLocalizer<App>>();
            context.JSInterop.SetupVoid("displayToast", "password-error-toast");
            profileComponent.Find("#confirmButton").Click();
            profileComponent.Find("#errorMessage").TextContent.MarkupMatches($"{localizer["ProfilePageEmptyUpdatePasswordFormErrorMessage"]}.");
        }
    }
}