using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MantenimientoClientesBOL.Models;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace MantenimientoClientesBOL

{
    public class ClienteDAO
    {

        string connectionString; 
        MySqlConnection connection= null;
        DataModel ctx = null;

        public ClienteDAO()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString;
                connection = new MySqlConnection(connectionString);
            }
            catch(Exception e )
            {
                throw (e);
            }
        }


        public void Eliminar(int? id)
        {
            Cliente cliente = null;
            try
            {
                
                cliente = new Cliente();
                cliente.idcliente = id;
                OpenConnection();
                using (ctx = new DataModel(connection, false))
                {
                    ctx.cliente.Attach(cliente);
                    ctx.cliente.Remove(cliente);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public Cliente AddEditCliente(int? idcliente, string Apellido, string Nombre, string Dni, string Sexo, string Edad, string Nivelestudios, string Telefono)
        {
            
            Cliente objCliente = null;
            try
            {
                OpenConnection();
                using (ctx = new DataModel(connection, false))
                {
                    if (idcliente.HasValue)
                        objCliente = ctx.cliente.FirstOrDefault(x => x.idcliente == idcliente);
                    else
                    {
                        objCliente = new Cliente();
                        ctx.cliente.Add(objCliente);
                    }

                    objCliente.Apellido = Apellido;
                    objCliente.Nombre = Nombre;
                    objCliente.Dni = Dni;
                    objCliente.Sexo = Sexo;
                    objCliente.Edad = Edad;
                    objCliente.Nivelestudios = Nivelestudios;
                    objCliente.Telefono = Telefono;

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return objCliente;

        }

        public List<Cliente> Listar(String filtro)
        {
            try
            {
                List<Cliente> lstClientes = new List<Cliente>();
                OpenConnection();
                using (ctx = new DataModel(connection, false))
                {
                    var query = ctx.cliente.AsQueryable();
                    if (!String.IsNullOrEmpty(filtro))
                    {
                        query = query.Where(x => x.Apellido.Contains(filtro));
                    }

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public Cliente Obtener(int? id)
        {
            try
            {
                OpenConnection();
                Cliente c = null;
                using (ctx = new DataModel(connection, false))
                {
                    c = ctx.cliente.FirstOrDefault(x => x.idcliente == id);
                }
                return c;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        

        public void OpenConnection()
        {
            connection.Open();

        }
        public void CloseConnection()
        {
            connection.Close();
        }

        public void Truncate()
        {
            OpenConnection();
            using (ctx = new DataModel(connection, false))
            {
                ctx.Database.ExecuteSqlCommand("Truncate Table cliente");
            }
            CloseConnection();
        }
    }
}



