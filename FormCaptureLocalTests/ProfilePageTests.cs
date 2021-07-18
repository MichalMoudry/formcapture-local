using Bunit;
using FormCaptureLocal.Pages.App.Profile;
using Xunit;

namespace FormCaptureLocalTests
{
    public class ProfilePageTests
    {
        [Fact]
        public void EmptyNewPasswordFormTest()
        {
            using var context = new TestContext();
            var profileComponent = context.RenderComponent<Profile>();
            context.JSInterop.SetupVoid("displayToast", "password-error-toast");
            profileComponent.Find("#confirmButton").Click();
            profileComponent.Find("#errorMessage").TextContent.MarkupMatches("Form for updating password is empty.");
        }
    }
}