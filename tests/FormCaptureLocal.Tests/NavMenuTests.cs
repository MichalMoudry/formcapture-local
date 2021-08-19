using Bunit;
using FormCaptureLocal;
using FormCaptureLocal.Shared;
using FormCaptureLocal.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Xunit;

namespace FormCaptureLocal.Tests
{
    /// <summary>
    /// Navigation menu tests.
    /// </summary>
    public class NavMenuTests
    {
        /// <summary>
        /// Test if navigation menu toggles correctly.
        /// </summary>
        [Fact]
        public void ToggleMenuTest()
        {
            using var context = new TestContext();
            //Add services to context
            _ = context.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            var navMenu = context.RenderComponent<NavMenu>();
            var beforeToggle = navMenu.Find("#navList").ClassList.Contains("collapse");
            navMenu.Find(".navbar-toggler").Click();
            var afterToggle = navMenu.Find("#navList").ClassList.Contains("collapse");
            Assert.NotEqual(beforeToggle, afterToggle);
        }
    }
}
