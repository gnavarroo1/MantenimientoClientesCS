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
using OpenQA.Selenium;
using System.Text.RegularExpressions;

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
        static List<ClienteBean> temp;
        int len = 0;
        AddEditClientePage addEdit;
        IWebDriver driver;


        [Test, Order(6)]
        [TestCase(TestName = "1- Login")]
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
                throw new ApplicationException(e.Message);
            }

        }


        [Test, Order(7)]
        [TestCase(TestName ="2- AgregarCliente")]
        [TestCaseSource("ExcelDataTest")]
        public void AgregarCliente(ClienteBean c)
        {
            String msg = "";
            //Assert.IsTrue(driver.Url.Equals(UrlListado));
            driver.FindElement(By.XPath("//*[@id='AgregarCliente']")).Click();
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
                throw e;
            }
            finally
            {
                len++;
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