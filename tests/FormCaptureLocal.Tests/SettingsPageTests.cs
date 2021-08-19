using Blazored.LocalStorage;
using Bunit;
using FormCaptureLocal;
using FormCaptureLocal.Models.Util.Enums;
using FormCaptureLocal.Pages.App.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FormCaptureLocal.Tests
{
    public class SettingsPageTests
    {
        [Fact]
        public async Task ChangeLocaleSettingTest()
        {
            using var context = new TestContext();
            _ = context.Services.AddLocalization(options => options.ResourcesPath = "Resources")
                                .AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>();
            context.AddBlazoredLocalStorage();
            var localStorage = context.Services.GetService<ILocalStorageService>();
            await localStorage.SetItemAsync(Setting.DefaultLocale.ToString(), Locale.eng.ToString());
            await localStorage.SetItemAsync(Setting.ApplicationTheme.ToString(), AppTheme.Light.ToString());
            var settingsComponent = context.RenderComponent<Settings>();
            var originalLocale = await localStorage.GetItemAsStringAsync(Setting.DefaultLocale.ToString());
            originalLocale = originalLocale.Replace("\"", "");
            settingsComponent.Find("select").Change("ces");
            settingsComponent.Find("#saveLocaleButton").Click();
            var newLocale = await localStorage.GetItemAsStringAsync(Setting.DefaultLocale.ToString());
            newLocale = newLocale.Replace("\"", "");
            Assert.NotEqual(originalLocale, newLocale);
        }

        [Fact]
        public async Task ChangeThemeSettingTest()
        {
            using var context = new TestContext();
            _ = context.Services.AddLocalization(options => options.ResourcesPath = "Resources")
                                .AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>();
            _ = context.AddBlazoredLocalStorage();
            var localStorage = context.Services.GetService<ILocalStorageService>();
            await localStorage.SetItemAsync(Setting.DefaultLocale.ToString(), Locale.eng.ToString());
            await localStorage.SetItemAsync(Setting.ApplicationTheme.ToString(), AppTheme.Light.ToString());
            var settingsComponent = context.RenderComponent<Settings>();
            string themeSettingValue = "";
            var res = false;
            foreach (var button in settingsComponent.FindAll("input"))
            {
                button.Click();
                themeSettingValue = await localStorage.GetItemAsStringAsync(Setting.ApplicationTheme.ToString());
                themeSettingValue = themeSettingValue.Replace("\"", "");
                if (Enum.GetNames(typeof(AppTheme)).Contains(themeSettingValue))
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            Assert.True(res);
        }

        [Fact]
        public async Task LoadThemeSettingTest()
        {
            using var context = new TestContext();
            _ = context.Services.AddLocalization(options => options.ResourcesPath = "Resources")
                            .AddSingleton<IStringLocalizer<App>, StringLocalizer<App>>();
            _ = context.AddBlazoredLocalStorage();
            var localStorage = context.Services.GetService<ILocalStorageService>();
            await localStorage.SetItemAsync(Setting.DefaultLocale.ToString(), Locale.eng.ToString());
            await localStorage.SetItemAsync(Setting.ApplicationTheme.ToString(), AppTheme.Light.ToString());
            var settingsComponent = context.RenderComponent<Settings>();
            settingsComponent.Find("#selectedTheme").TextContent.MarkupMatches("Light");
        }
    }
}