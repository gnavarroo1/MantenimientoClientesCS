using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace MantenimientoClientes.DAL
{
    public static class utilExtension
    {
        public static List<T> DataTableToList<T>(DataTable table)
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
