using Bunit;
using FormCaptureLocal;
using FormCaptureLocal.Pages.Index;
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
            context.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            context.Services.AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>();
            var localizer = context.Services.GetService<IStringLocalizer<App>>();
            var registerComponent = context.RenderComponent<Register>();
            registerComponent.Find("#submitButton").Click();
            var errorAlertText = registerComponent.Find(".alert").TextContent;
            Assert.Equal(localizer["RegistrationEmptyFormError"], errorAlertText);
        }
    }
}