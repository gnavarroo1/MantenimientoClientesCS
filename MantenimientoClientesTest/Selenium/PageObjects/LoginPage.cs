using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MantenimientoClientesTest.Selenium
{
    class LoginPage
    {
        private IWebDriver driver = null;
        public LoginPage(string navegador)
        {
            driver = Driver.InicializarWebDriver(navegador);
        }
        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement Usuario { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement Ingresar { get; set; }

        public IWebElement ErrorDisplay { get; set; }

    }
}
