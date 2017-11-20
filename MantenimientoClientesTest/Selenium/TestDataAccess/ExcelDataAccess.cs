
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;


namespace MantenimientoClientesSeleniumTests.Selenium.TestDataAccess
{
    public class ExcelDataAccess
    {
        private string ExcelPath = ConfigurationManager.AppSettings["TestDataSheetPath"];

        public List<ClienteBean> ReadFromExcel(string keyName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ExcelPath);

            List<ClienteBean> clientes = new List<ClienteBean>();
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbooks ExcelWorkbooks;
            Excel.Workbook ExcelWorkbook;
            Excel.Worksheet ExcelWorksheet;
            Excel.Range ExcelRange;

            ExcelWorkbooks = ExcelApp.Workbooks;
            ExcelWorkbook = ExcelWorkbooks.Open(path);
            ExcelWorksheet = ExcelWorkbook.Sheets[1];
            ExcelRange = ExcelWorksheet.UsedRange;

            int rowCount = ExcelRange.Rows.Count;
            int colCount = ExcelRange.Columns.Count;

            string[] headers = new string[colCount];
            for (int i = 1; i <= colCount; i++)
            {
                headers[i - 1] = (Convert.ToString((ExcelRange.Cells[1, i] as Excel.Range).Value2));

            }
            for (int j = 2; j <= rowCount; j++)
            {


                string Key = Convert.ToString((ExcelRange.Cells[j, 1] as Excel.Range).Value2);
                if (Key.Equals(keyName))
                {
                    ClienteBean clienteBean = new ClienteBean();
                    clienteBean.Apellido = Convert.ToString((ExcelRange.Cells[j, 2] as Excel.Range).Value2);
                    clienteBean.Nombre = Convert.ToString((ExcelRange.Cells[j, 3] as Excel.Range).Value2);
                    clienteBean.Dni = Convert.ToString((ExcelRange.Cells[j, 4] as Excel.Range).Value2);
                    clienteBean.Sexo = Convert.ToString((ExcelRange.Cells[j, 5] as Excel.Range).Value2);
                    clienteBean.Nivelestudios = Convert.ToString((ExcelRange.Cells[j, 6] as Excel.Range).Value2);
                    clienteBean.Telefono = Convert.ToString((ExcelRange.Cells[j, 7] as Excel.Range).Value2);
                    clienteBean.Edad = Convert.ToString((ExcelRange.Cells[j, 8] as Excel.Range).Value2);
                    clienteBean.Resultado = Convert.ToString((ExcelRange.Cells[j, 9] as Excel.Range).Value2);
                    clientes.Add(clienteBean);
                }
                continue;

            }

            ExcelWorkbook.Close();
            ExcelWorkbooks.Close();
            ExcelApp.Quit();

            Marshal.ReleaseComObject(ExcelRange);
            Marshal.ReleaseComObject(ExcelWorksheet);
            Marshal.ReleaseComObject(ExcelWorkbooks);
            Marshal.ReleaseComObject(ExcelWorkbook);
            Marshal.ReleaseComObject(ExcelApp);

            return clientes;


        }


        /*
        private static List<T> DataTableToList<T>(DataTable table)
        {
            try
            {
                List<T> list = new List<T>();
                foreach (DataRow row in table.Rows)
                {
                    T item = GetItem<T>(row);
                    list.Add(item);

                }
                return list;
            }
            catch
            {
                return null;
            }
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        */
    }


}

