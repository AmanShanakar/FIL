// Here only used Playwright
using Microsoft.Playwright;

namespace PalywrightDemo
{
    public class Tests
    {
        [Test]
        public async Task Test1()
        {
            //Create Playwright
            var playwright = await Playwright.CreateAsync();

            //browser
            // By default all the browser Headless id true
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            //Page Creation
            var page = await browser.NewPageAsync();

            await page.GotoAsync("http://www.eaapp.somee.com"); //Navigation to the particular site
            await page.ClickAsync(selector: "text=Login");
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "Login_Page.jpg"
            });

            await page.FillAsync(selector: "#UserName", value: "admin");
            await page.FillAsync(selector: "#Password", value: "password");
            await page.ClickAsync("text=Log in");

            var isExist = await page.Locator(selector:"text='Employee Details'").IsVisibleAsync();
            Assert.IsTrue(isExist);
        }
    }
}