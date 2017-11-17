using System;
using System.Text;
using System.Collections.Generic;
using MantenimientoClientesTest.Selenium;
using System.Configuration;
using NUnit.Framework;
using MantenimientoClientesTest.Selenium.PageObjects;
using MantenimientoClientesTest.Selenium.Driver;
using MantenimientoClientesTest.Selenium.TestDataAccess;
using System.ComponentModel;

namespace MantenimientoClientesTest.Selenium.TestCases
{
    /// <summary>
    /// Summary description for TestList
    /// </summary>
    public class TestList
    {

        private string UrlInicial = ConfigurationManager.AppSettings["urlInicial"];
        private string UrlListado = ConfigurationManager.AppSettings["urlListado"];
        LoginPage loginPage;
        AddEditClientePage addEdit;
        

        [Test]
        public void IniciarSesionValid()
        {
            loginPage = new LoginPage("chrome", UrlInicial);
            try
            {
                Assert.IsTrue(loginPage.IniciarSesion("admin", "clave"));
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
           
        }

        [Test]
        [TestCaseSource("ExcelDataTest")]
        public void AgregarCliente(ClienteBean c)
        {
            String msg = "";
            try
            {
                
                addEdit = new AddEditClientePage(loginPage.GetWebDriver());
                Assert.IsTrue(addEdit.Driver.Equals(UrlListado));
                msg = addEdit.Insertar(c);
                Assert.IsTrue(msg.Equals(c.Resultado));
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                WebDriver.CerrarPagina(addEdit.Driver);
            }
        }

    

        public static IEnumerable<TestCaseData> ExcelDataTest
        {
            get
            {
                
                List<ClienteBean> lstClientes = ExcelDataAccess.GetTestData("Insertar"); ;
                if (lstClientes != null)
                    foreach (ClienteBean cliente in lstClientes)
                        yield return new TestCaseData(cliente);

            }
        }




    }

        
}
