using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavascriptProxy
{
    class Program
    {
        public static IWebDriver driver;
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                //Remove this if statment, if you want to work with protocols other than HTTP/HTTPS
                if (args[0].ToLower().StartsWith("http") == false)
                    args[0] = "http://" + args[0];

                Program program = new Program();
                program.InitDriver();
                program.Get(args[0]);
            }
        }
        public void InitDriver()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("headless");
            driver = new ChromeDriver(driverService, options);
            driver.Manage().Window.Minimize();
        }
        public void Get(string URL)
        {
            Console.Title = "JavaScriptProxy: " + URL.ToLower();
            driver.Url = URL;
            Console.WriteLine(RemoveWhitespace(driver.PageSource));
            driver.Close();
            driver.Dispose();
        }
        public string RemoveWhitespace(string input)
        {
            return input.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\t", string.Empty);
        }
    }
}
