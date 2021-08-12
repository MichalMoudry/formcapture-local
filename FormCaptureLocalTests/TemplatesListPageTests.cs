using Bunit;
using FormCaptureLocal;
using FormCaptureLocal.Models.DbModels;
using FormCaptureLocal.Pages.App.Templates;
using FormCaptureLocal.Services;
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
            //Add services to context
            _ = context.Services.AddLocalization(options => options.ResourcesPath = "Resources")
                            .AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>()
                            .AddSingleton<DataAccess>()
                            .AddSingleton<AlertService>();
            _ = context.JSInterop.Setup<List<Template>>("getAllItems", "Templates");
            _ = context.JSInterop.SetupVoid("displayToast", "error-toast");
            var templatesListComponent = context.RenderComponent<TemplatesList>();
            var templatesCount = templatesListComponent.FindAll(".pointer").Count;
            //Get localizer
            var localizer = context.Services.GetService<IStringLocalizer<App>>();
            Assert.Equal(0, templatesCount);
            templatesListComponent.Find(".dropdown-item").Click();
            var errorMessage = templatesListComponent.Find(".errorMessage").TextContent;
            Assert.Equal($"{localizer["TemplatesListPageSortNullTemplatesError"]}.", errorMessage);
        }
    }
}