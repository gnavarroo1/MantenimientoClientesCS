
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace MantenimientoClientesTest
{

    public class Driver
    {
        public static IWebDriver InicializarWebDriver(string navegador)
        {
            IWebDriver driver = null;

            switch (navegador)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return driver;
        }

        public static void CerrarPagina(IWebDriver webDriver)
        {
            if(webDriver != null)
            {
                webDriver.Quit();
            }
        }
    }
}
