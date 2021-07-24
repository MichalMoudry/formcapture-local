using Bunit;
using FormCaptureLocal;
using FormCaptureLocal.Models.DbModels;
using FormCaptureLocal.Pages.App.Templates;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using Xunit;

namespace FormCaptureLocalTests
{
    public class TemplatesListPageTests
    {
        [Fact]
        public void EmptyTemplatesSortErrorTest()
        {
            using var context = new TestContext();
            context.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            context.Services.AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>();
            context.JSInterop.Setup<List<Template>>("getAllItems", "Templates");
            context.JSInterop.SetupVoid("displayToast", "error-toast");
            var templatesListComponent = context.RenderComponent<TemplatesList>();
            var templatesCount = templatesListComponent.FindAll(".pointer").Count;
            var localizer = context.Services.GetService<IStringLocalizer<App>>();
            Assert.Equal(0, templatesCount);
            templatesListComponent.Find(".dropdown-item").Click();
            var errorMessage = templatesListComponent.Find(".errorMessage").TextContent;
            Assert.Equal($"{localizer["TemplatesListPageSortNullTemplatesError"]}.", errorMessage);
        }
    }
}