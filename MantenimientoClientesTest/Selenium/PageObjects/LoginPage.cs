using MantenimientoClientesSeleniumTests.Selenium.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Configuration;
using System.Threading;

namespace MantenimientoClientesSeleniumTests.Selenium.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver = null;
        private string urlInicial;
        private string urlListado = ConfigurationManager.AppSettings["urlListado"];
        public LoginPage(string navegador, string urlInicial)
        {
            this.urlInicial = urlInicial;
            this.driver = WebDriver.InicializarWebDriver(navegador);
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "username")]
        [CacheLookup]
        public IWebElement Usuario { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        [CacheLookup]
        public IWebElement Ingresar { get; set; }


        [FindsBy(How = How.Id, Using = "LoginErrorMsg")]
        [CacheLookup]
        public IWebElement ErrorDisplay { get; set; }



        public bool IniciarSesion(string usuario, string clave)
        {
            driver.Url = urlInicial;
            Usuario.Clear();
            Usuario.SendKeys(usuario);
            Password.Clear();
            Password.SendKeys(clave);
            Ingresar.Click();
            
            return driver.Url.Equals(urlListado);
        }

        public void CerrarPagina()
        {
            WebDriver.CerrarPagina(driver);
        }

        public IWebDriver GetWebDriver()
        {
            return driver;
        }
    }
}
