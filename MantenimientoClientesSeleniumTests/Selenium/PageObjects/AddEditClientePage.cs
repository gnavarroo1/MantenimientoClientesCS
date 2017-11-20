using MantenimientoClientesSeleniumTests.Selenium.Driver;
using MantenimientoClientesSeleniumTests.Selenium.TestDataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace MantenimientoClientesSeleniumTests.Selenium.PageObjects
{
    class AddEditClientePage
    {
        private IWebDriver driver = null;

        public AddEditClientePage(string navegador)
        {
            this.driver = WebDriver.InicializarWebDriver(navegador);
            PageFactory.InitElements(driver, this);
        }

        public AddEditClientePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /*
        [FindsBy(How = How.XPath,Using = "//*[@id='AgregarCliente']")]
        public IWebElement AgregarCliente { get; set; }
        */
        [FindsBy(How = How.Id, Using = "Apellido")]
        [CacheLookup]
        public IWebElement Apellido { get; set; }

        [FindsBy(How = How.Id, Using = "Nombre")]
        [CacheLookup]
        public IWebElement Nombre { get; set; }

        [FindsBy(How = How.Id, Using = "Dni")]
        [CacheLookup]
        public IWebElement Dni { get; set; }

        [FindsBy(How = How.Id, Using = "SexoMasc")]
        [CacheLookup]
        public IWebElement SexoMasc { get; set; }

        [FindsBy(How = How.Id, Using = "SexoFem")]
        [CacheLookup]
        public IWebElement SexoFem { get; set; }

        [FindsBy(How = How.Id, Using = "Nivelestudios")]
        [CacheLookup]
        public IWebElement NivelEstudios { get; set; }

        [FindsBy(How = How.Id, Using = "Edad")]
        [CacheLookup]
        public IWebElement Edad { get; set; }

        [FindsBy(How = How.Id, Using = "Telefono")]
        [CacheLookup]
        public IWebElement Telefono { get; set; }

        [FindsBy(How = How.Id, Using = "apellidoError")]
        [CacheLookup]
        public IWebElement ApellidoErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "nombreError")]
        [CacheLookup]
        public IWebElement NombreErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "dniError")]
        [CacheLookup]
        public IWebElement DniErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "edadError")]
        [CacheLookup]
        public IWebElement EdadErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "sexoError")]
        [CacheLookup]
        public IWebElement SexoErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "telfError")]
        [CacheLookup]
        public IWebElement TelefonoErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "nivelError")]
        [CacheLookup]
        public IWebElement NivelEstudiosErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "AddEditSuccessMsg")]
        [CacheLookup]
        public IWebElement AddEditSuccessDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "btnGuardar")]
        [CacheLookup]
        public IWebElement Guardar { get; set; }
        public IWebDriver Driver { get => driver; set => driver = value; }

        public string Insertar(ClienteBean c)
        {
            string message = "";
            SelectElement oSelect = new SelectElement(NivelEstudios);
            try
            {
                //      AgregarCliente.Click();
                Apellido.Clear();
                if(!String.IsNullOrEmpty(c.Apellido))
                    Apellido.SendKeys(c.Apellido);
                Nombre.Clear();
                if (!String.IsNullOrEmpty(c.Nombre))
                    Nombre.SendKeys(c.Nombre);
                Dni.Clear();
                if (!String.IsNullOrEmpty(c.Dni))
                    Dni.SendKeys(c.Dni);
                if (c.Sexo.Equals("MASCULINO"))
                {
                    SexoMasc.Click();
                }
                if (c.Sexo.Equals("FEMENINO"))
                {
                    SexoFem.Click();
                }
                Edad.Clear();
                if (!String.IsNullOrEmpty(c.Edad))
                    Edad.SendKeys(c.Edad);
                if (!String.IsNullOrEmpty(c.Nivelestudios))
                    oSelect.SelectByText(c.Nivelestudios);
                Telefono.Clear();
                if (!String.IsNullOrEmpty(c.Telefono))
                    Telefono.SendKeys(c.Telefono);
                Guardar.Click();

                if (!String.IsNullOrEmpty(ApellidoErrorDisplay.Text))
                    message = ApellidoErrorDisplay.Text;
                if (!String.IsNullOrEmpty(NombreErrorDisplay.Text))
                    message = NombreErrorDisplay.Text;
                if (!String.IsNullOrEmpty(DniErrorDisplay.Text))
                    message = DniErrorDisplay.Text;
                if (!String.IsNullOrEmpty(SexoErrorDisplay.Text))
                    message = SexoErrorDisplay.Text;
                if (!String.IsNullOrEmpty(NivelEstudiosErrorDisplay.Text))
                    message = NivelEstudiosErrorDisplay.Text;
                if (!String.IsNullOrEmpty(NivelEstudiosErrorDisplay.Text))
                    message = NivelEstudiosErrorDisplay.Text;
                if (!String.IsNullOrEmpty(TelefonoErrorDisplay.Text))
                    message = TelefonoErrorDisplay.Text;

                if (!String.IsNullOrEmpty(AddEditSuccessDisplay.Text))
                    message = AddEditSuccessDisplay.Text;

                return message;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }



    }
}
