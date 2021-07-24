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
            context.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            context.Services.AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>();
            var profileComponent = context.RenderComponent<Profile>();
            context.JSInterop.SetupVoid("displayToast", "password-error-toast");
            profileComponent.Find("#confirmButton").Click();
            profileComponent.Find("#errorMessage").TextContent.MarkupMatches("Form for updating password is empty.");
        }
    }
}