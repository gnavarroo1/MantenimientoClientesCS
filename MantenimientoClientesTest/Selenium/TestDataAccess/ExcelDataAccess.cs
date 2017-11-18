
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;



namespace MantenimientoClientesTest.Selenium.TestDataAccess
{
    public class ExcelDataAccess
    {
        private string excelPath = ConfigurationManager.AppSettings["TestDataSheetPath"];

        public List<ClienteBean> ReadFromExcel(string keyName)
        {
 
            string pathbase = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string path = Path.Combine(pathbase, excelPath);
            List<ClienteBean> clientes = new List<ClienteBean>();
            //bool e = File.Exists(path);
            using (var stream = File.Open(path, FileMode.Open,FileAccess.Read, FileShare.Read))
            {

                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    
                    
                    // 2. Use the AsDataSet extension method
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });


                    foreach (DataTable table in result.Tables)
                    {
                        clientes = DataTableToList<ClienteBean>(table);
                        break;
                        
                    }
                    
                }
            }
            
            return clientes;
        }

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
    }


}

