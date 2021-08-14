using Bunit;
using FormCaptureLocal;
using FormCaptureLocal.Pages.Index;
using FormCaptureLocal.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Xunit;

namespace FormCaptureLocalTests
{
    public class RegisterPageTests
    {
        [Fact]
        public void EmptyFieldsTest()
        {
            using var context = new TestContext();
            _ = context.Services.AddLocalization(options => options.ResourcesPath = "Resources")
                            .AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>().AddSingleton<DataAccess>();
            var localizer = context.Services.GetService<IStringLocalizer<App>>();
            var registerComponent = context.RenderComponent<Register>();
            registerComponent.Find("#submitButton").Click();
            var errorAlertText = registerComponent.Find(".alert").TextContent;
            Assert.Equal(localizer["RegistrationEmptyFormError"], errorAlertText);
        }
    }
}