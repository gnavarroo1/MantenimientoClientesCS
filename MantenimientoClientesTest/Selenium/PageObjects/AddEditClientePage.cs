using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MantenimientoClientesTest.Selenium.PageObjects
{
    class AddEditClientePage
    {
        private IWebDriver driver = null;

        public AddEditClientePage(string navegador)
        {
            driver = Driver.InicializarWebDriver(navegador);
        }

        [FindsBy(How = How.Id, Using = "Apellido")]
        public IWebElement Apellido { get; set; }

        [FindsBy(How = How.Id, Using = "Nombre")]
        public IWebElement Nombre { get; set; }

        [FindsBy(How = How.Id, Using = "Dni")]
        public IWebElement Dni { get; set; }

        [FindsBy(How = How.Id, Using = "Sexo")]
        public IWebElement Sexo { get; set; }

        [FindsBy(How = How.Id, Using = "Nivelestudios")]
        public IWebElement NivelEstudios { get; set; }

        [FindsBy(How = How.Id, Using = "Edad")]
        public IWebElement Edad { get; set; }

        [FindsBy(How = How.Id, Using = "Telefono")]
        public IWebElement Telefono { get; set; }

        [FindsBy(How = How.Id, Using = "apellidoError")]
        public IWebElement ApellidoErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "nombreError")]
        public IWebElement NombreErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "dniError")]
        public IWebElement DniErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "edadError")]
        public IWebElement EdadErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "sexoError")]
        public IWebElement SexoErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "telefonoError")]
        public IWebElement TelefonoErrorDisplay { get; set; }

        [FindsBy(How = How.Id, Using = "nivelError")]
        public IWebElement NivelEstudiosErrorDisplay { get; set; }


        [FindsBy(How = How.Id, Using = "btnGuardar")]
        public IWebElement Guardar { get; set; }

    }
}
