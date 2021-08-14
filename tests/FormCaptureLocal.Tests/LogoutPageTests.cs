using Blazored.LocalStorage;
using Bunit;
using FormCaptureLocal.Pages.App;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FormCaptureLocalTests
{
    public class LogoutPageTests
    {
        [Fact]
        public async Task LogoutTest()
        {
            using var context = new TestContext();
            context.AddBlazoredLocalStorage();
            var localStorage = context.Services.GetService<ILocalStorageService>();
            await localStorage.SetItemAsync("LastLoginDate", DateTime.Now);
            context.RenderComponent<Logout>();
            bool containsLastLoginDate = await localStorage.ContainKeyAsync("LastLoginDate");
            Assert.False(containsLastLoginDate);
        }
    }
}