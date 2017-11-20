using System;
using System.Text;
using System.Collections.Generic;
using MantenimientoClientesSeleniumTests.Selenium;
using System.Configuration;
using NUnit.Framework;
using MantenimientoClientesSeleniumTests.Selenium.PageObjects;
using MantenimientoClientesSeleniumTests.Selenium.Driver;
using MantenimientoClientesSeleniumTests.Selenium.TestDataAccess;
using System.ComponentModel;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace MantenimientoClientesSeleniumTests.Selenium.TestCases
{
    /// <summary>
    /// Summary description for TestList
    /// </summary>
    public class TestList
    {
        
        private string UrlInicial = ConfigurationManager.AppSettings["urlInicial"];
        private string UrlAddEdit = ConfigurationManager.AppSettings["urlAddEdit"];
        private string UrlListado = ConfigurationManager.AppSettings["urlListado"];
        LoginPage loginPage;
        static List<ClienteBean> temp;
        int len = 0;
        AddEditClientePage addEdit;
        IWebDriver driver;


        [Test, Order(1)]
        public void IniciarSesionValid()
        {
            loginPage = new LoginPage("chrome", UrlInicial);

            try
            {
                driver = loginPage.GetWebDriver();
                Assert.IsTrue(loginPage.IniciarSesion("admin", "clave"));
            }
            catch (Exception e)
            {
                TearDown();
                throw new ApplicationException(e.Message);
            }

        }


        [Test, Order(2)]
        [TestCaseSource("ExcelDataTest")]
        public void AgregarCliente(ClienteBean c)
        {
            String msg = "";
            Assert.IsTrue(driver.Url.Equals(UrlListado));
            driver.Url = UrlAddEdit;
            try
            {
                addEdit = new AddEditClientePage(driver);
                msg = addEdit.Insertar(c);
                msg = Regex.Replace(msg, @"\u0020", " ");
                string esp = Regex.Replace(c.Resultado, @"\u00A0", " ");
                bool b = msg.Equals(esp);
                Assert.IsTrue(msg.Equals(esp));
            }
            catch (Exception e)
            {
                TearDown();
                throw e;
            }
            finally
            {
                len++;
                driver.Url = UrlListado;
                if (len == temp.Count)
                    TearDown();
            }
        }

        private static IEnumerable<TestCaseData> ExcelDataTest
        {
            get
            {
                List<ClienteBean> lstClientes = (new ExcelDataAccess()).ReadFromExcel("Insertar"); ;
                temp = lstClientes;
                if (lstClientes != null)
                    foreach (ClienteBean cliente in lstClientes)
                        yield return new TestCaseData(cliente);

            }
        }


        public void TearDown()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }

    
    }
}