using Bunit;
using FormCaptureLocal.Pages.Index;
using Xunit;

namespace FormCaptureLocalTests
{
    public class RegisterPageTests
    {
        [Fact]
        public void EmptyFieldsTest()
        {
            using var context = new TestContext();
            var registerComponent = context.RenderComponent<Register>();
            registerComponent.Find("#submitButton").Click();
            var errorAlertText = registerComponent.Find(".alert").TextContent;
            Assert.Equal("Registration form wasn't properly completed.", errorAlertText);
        }
    }
}