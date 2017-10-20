using System;
using System.Data;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MantenimientoClientes.DAL
{
    public class DataAccess
    {

        MySqlConnection con;
        MySqlDataAdapter da;

        MySqlConnection GetConnectionMySQL()
        {
            return new MySqlConnection("id=root;password=root;server=localhost;database=bdcliente");
        }

        void CloseConnectionMySQL(MySqlConnection con)
        {
            if(con != null)
            {
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        
        public DataTable GetTable(String command)
        {
            con = GetConnectionMySQL();
            try
            {
                con.Open();
                DataTable dataTable = new DataTable();
                da = new MySqlDataAdapter(command, con);
                da.Fill(dataTable);
                return dataTable;
            }
            catch (MySqlException)
            {

                throw new ApplicationException("El servidor de datos no esta disponible");
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally { CloseConnectionMySQL(con); }
        }

        public void ExecuteQuery(String command)
        {
            con = GetConnectionMySQL();
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(command, con);
                com.ExecuteNonQuery();
            }
            catch (MySqlException)
            {

                throw new ApplicationException("El servidor de datos no esta disponible");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally { CloseConnectionMySQL(con); }
        }
        
    }
}
