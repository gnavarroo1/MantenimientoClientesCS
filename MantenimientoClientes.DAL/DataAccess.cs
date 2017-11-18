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
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;
        public DataAccess()
        {
            Initialize();
        }
        private void Initialize()
        {
            server = "localhost";
            database = "bdcliente";
            uid = "root";
            password = "root";
            port = "3306";
            string connectionString;
            //connectionString = "SERVER=" + server + ";"+ "PORT=" + port + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            con = new MySqlConnection(connectionString);
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

        public long? ExecuteQuery(string command)
        {
            long? id = null;
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand com = new MySqlCommand(command, con);
                    var obj = com.ExecuteReader();
                    id = com.LastInsertedId;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw new ApplicationException(ex.Message);
            }
            finally { CloseConnectionMySQL(con); }
            return id;
        }

        public void TruncateTable()
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand com = new MySqlCommand("TRUNCATE TABLE cliente", con);
                    com.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw new ApplicationException(ex.Message);
            }
            finally { CloseConnectionMySQL(con); }
        }




        private bool OpenConnection()
        {
            try
            {
                con.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        throw new ApplicationException("Cannot connect to server.  Contact administrator");
                    case 1045:
                        throw new ApplicationException("Invalid username/password, please try again");
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                con .Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw new ApplicationException(ex.Message);
                
            }
            
        }
    }
}
