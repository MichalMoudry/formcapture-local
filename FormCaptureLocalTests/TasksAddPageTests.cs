using Bunit;
using FormCaptureLocal;
using FormCaptureLocal.Pages.App.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Xunit;

namespace FormCaptureLocalTests
{
    public class TasksAddPageTests
    {
        /// <summary>
        /// Test method for testing if error message is displayed properly.
        /// </summary>
        [Fact]
        public void EmptyTaskContentTest()
        {
            using var context = new TestContext();
            //Add services to context
            context.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            context.Services.AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>();
            context.JSInterop.SetupVoid("displayToast", "error-toast");
            //Get localizer
            var localizer = context.Services.GetService<IStringLocalizer<App>>();
            //Render component
            var tasksAddComponent = context.RenderComponent<TasksAdd>();
            //Click test button
            tasksAddComponent.Find("#testButton").Click();
            var errorMessage = tasksAddComponent.Find(".errorMessage").TextContent;
            Assert.Equal($"{localizer["TasksAddPageEmptyTaskContentErrorMessage"]}.", errorMessage);
        }

        /// <summary>
        /// Test method for testing if error message is displayed properly.
        /// </summary>
        [Fact]
        public void EmptyTaskNameTest()
        {
            using var context = new TestContext();
            //Add services to context
            context.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            context.Services.AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>();
            context.JSInterop.SetupVoid("displayToast", "error-toast");
            //Get localizer
            var localizer = context.Services.GetService<IStringLocalizer<App>>();
            //Render component
            var tasksAddComponent = context.RenderComponent<TasksAdd>();
            //Click submit button
            tasksAddComponent.Find("#submitButton").Click();
            var errorMessage = tasksAddComponent.Find(".errorMessage").TextContent;
            Assert.Equal($"{localizer["TasksAddPageEmptyTaskNameErrorMessage"]}.", errorMessage);
        }
    }
}