using MantenimientoClientesTest.Selenium.Driver;
using MantenimientoClientesTest.Selenium.TestDataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace MantenimientoClientesTest.Selenium.PageObjects
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
        }


        [FindsBy(How = How.XPath,Using = "//*[@id='AgregarCliente']")]
        public IWebElement AgregarCliente { get; set; }

        [FindsBy(How = How.Id, Using = "Apellido")]
        [CacheLookup]
        public IWebElement Apellido { get; set; }

        [FindsBy(How = How.Id, Using = "Nombre")]
        [CacheLookup]
        public IWebElement Nombre { get; set; }

        [FindsBy(How = How.Id, Using = "Dni")]
        [CacheLookup]
        public IWebElement Dni { get; set; }

        [FindsBy(How = How.Id, Using = "Sexo")]
        [CacheLookup]
        public IWebElement Sexo { get; set; }

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

        [FindsBy(How = How.Id, Using = "telefonoError")]
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
                AgregarCliente.Click();
                Apellido.Clear();
                Apellido.SendKeys(c.Apellido);
                Edad.Clear();
                Edad.SendKeys(c.Edad);
                Nombre.Clear();
                Nombre.SendKeys(c.Nombre);
                Dni.Clear();
                Dni.SendKeys(c.Dni);
                Sexo.Clear();
                Sexo.SendKeys(c.Sexo);
                oSelect.SelectByText(c.Nivelestudios);
                Telefono.Clear();
                Telefono.SendKeys(c.Telefono);
                Guardar.Click();

                if (!String.IsNullOrEmpty(ApellidoErrorDisplay.Text))
                    message= ApellidoErrorDisplay.Text;
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
