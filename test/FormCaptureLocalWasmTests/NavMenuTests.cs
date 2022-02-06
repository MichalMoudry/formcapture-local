using Xunit;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using FormCaptureLocalWasm.Shared.Components;

namespace FormCaptureLocalWasmTests
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