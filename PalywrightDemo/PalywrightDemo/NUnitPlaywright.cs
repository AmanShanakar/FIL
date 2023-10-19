// Here used Playwright.NUnit by inheriting PageTest
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PalywrightDemo
{
    public class NUnitPlaywright : PageTest
    {
        [Test]
        public async Task Test1()
        {
            // PageTest is Inheriting from ContextTest & that ContextTest Inheriting from BrowserTest & that BrowserTest Inheriting from Playwright

            await Page.GotoAsync("http://www.eaapp.somee.com"); //Navigation to the particular site
            await Page.ClickAsync("text=Login");

            await Page.FillAsync(selector: "#UserName", value: "admin");
            await Page.FillAsync(selector: "#Password", value: "password");
            await Page.ClickAsync(selector:"text=Log in");

            await Expect(Page.Locator(selector: "text='Manage Users'")).ToBeVisibleAsync();
        }
    }
}