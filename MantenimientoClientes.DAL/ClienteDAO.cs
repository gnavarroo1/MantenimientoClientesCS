using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using MantenimientoClientesBOL.Models;

namespace MantenimientoClientes.DAL

{
    public class ClienteDAO : DataAccess, Base<Cliente, int?>
    {

        #region Base<Cliente, String> Members;

        public void Actualizar(Cliente e)
        {
            try
            {
                ExecuteQuery("UPDATE Cliente SET Apellido ='" + e.Apellido + "'" +
                             ",Nombre = '" + e.Nombre + 
                             "',Dni ='" + e.Dni +
                             "',Sexo= '" + e.Sexo +
                             "',Edad= '" + e.Edad +
                             "',Nivelestudios = '" + e.Nivelestudios +
                             "',Telefono'" + e.Telefono + "' WHERE idcliente = '" + e.idcliente + "'");


            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }

        }

        public void Eliminar(int? id)
        {
            try
            {
                ExecuteQuery("DELETE FROM Cliente where idcliente = '" + id + "'");
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public void InsertarActualizar(Cliente e)
        {
            try
            {
                ExecuteQuery("Insert into Cliente(idcliente,Apellido,Nombre,Dni,Sexo,Edad,Nivelestudios,Telefono) values ('" + e.idcliente + "','"
                                                                                                                             + e.Apellido + "','"
                                                                                                                             + e.Nombre + "','"
                                                                                                                             + e.Dni + "','"
                                                                                                                             + e.Sexo + "','"
                                                                                                                             + e.Edad + "','"
                                                                                                                             + e.Nivelestudios + "','"
                                                                                                                             + e.Telefono + "' ) ON DUPLICATE KEY " +
                                                                                                                             "UPDATE Apellido ='" + e.Apellido + "'" +
                                                                                                                             ",Nombre = '" + e.Nombre +
                                                                                                                             "',Dni ='" + e.Dni +
                                                                                                                             "',Sexo= '" + e.Sexo +
                                                                                                                             "',Edad= '" + e.Edad +
                                                                                                                             "',Nivelestudios = '" + e.Nivelestudios +
                                                                                                                             "',Telefono'" + e.Telefono);
                
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public List<Cliente> Listar()
        {
            try
            {
                List<Cliente> lstClientes = new List<Cliente>();
                DataTable dt = GetTable("SELECT * FROM CLIENTE ORDER BY Nombre");
                if (dt.Rows.Count > 0)
                {
                    lstClientes = dt.DataTableToList<Cliente>();
                }
                return lstClientes;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
        public List<Cliente> Listar(String condicion)
        {
            try
            {
                List<Cliente> lstClientes = new List<Cliente>();
                DataTable dt = GetTable("SELECT * FROM Cliente WHERE Apellido  = '" + condicion+"'");
                if (dt.Rows.Count > 0)
                {
                    lstClientes = dt.DataTableToList<Cliente>();
                }
                return lstClientes;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public Cliente Obtener(int? id)
        {
            try
            {
                Cliente c = new Cliente();
                DataTable dt = GetTable("Select c from Cliente where idcliente = '" + id + "'");
                if(dt.Rows.Count>0)
                {
                    c = dt.DataTableToList<Cliente>()[0];
                }

                return c;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }


        #endregion
    }
}



