
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

using excel = Microsoft.Office.Interop.Excel;


namespace MantenimientoClientesTest.Selenium.TestDataAccess
{
    public class ExcelDataAccess
    {
        private string excelPath = ConfigurationManager.AppSettings["TestDataSheetPath"];

        public List<ClienteBean> ReadFromExcel(string keyName)
        {

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, excelPath);
            
            List<ClienteBean> clientes = new List<ClienteBean>();
            excel.Application excelApp = new excel.Application();
            excel.Workbook excelWorkbook;
            excel.Worksheet excelWorksheet;
            excel.Range excelRange;

            excelWorkbook = excelApp.Workbooks.Open(path);
            excelWorksheet = excelWorkbook.Sheets[1];
            excelRange = excelWorksheet.UsedRange;

            int rowCount = excelRange.Rows.Count;
            int colCount = excelRange.Columns.Count;

            string[] headers = new string[colCount];
            for (int i = 1; i <= colCount; i++)
            {
                headers[i - 1] = (Convert.ToString((excelRange.Cells[1, i] as excel.Range).Value2));

            }
            for (int j = 2; j <= rowCount; j++)
            {


                string Key = Convert.ToString((excelRange.Cells[j, 1] as excel.Range).Value2);
                if (Key.Equals(keyName))
                {
                    ClienteBean clienteBean = new ClienteBean();
                    clienteBean.Apellido = Convert.ToString((excelRange.Cells[j, 2] as excel.Range).Value2);
                    clienteBean.Nombre = Convert.ToString((excelRange.Cells[j, 3] as excel.Range).Value2);
                    clienteBean.Dni = Convert.ToString((excelRange.Cells[j, 4] as excel.Range).Value2);
                    clienteBean.Sexo = Convert.ToString((excelRange.Cells[j, 5] as excel.Range).Value2);
                    clienteBean.Nivelestudios = Convert.ToString((excelRange.Cells[j, 6] as excel.Range).Value2);
                    clienteBean.Telefono = Convert.ToString((excelRange.Cells[j, 7] as excel.Range).Value2);
                    clienteBean.Edad = Convert.ToString((excelRange.Cells[j, 8] as excel.Range).Value2);
                    clienteBean.Resultado = Convert.ToString((excelRange.Cells[j, 9] as excel.Range).Value2);
                    clientes.Add(clienteBean);
                }
                continue;

            }



            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(excelRange);
            Marshal.ReleaseComObject(excelWorksheet);
            excelApp.Workbooks.Close();
            Marshal.ReleaseComObject(excelWorkbook);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            return clientes;
        }


    }


}

