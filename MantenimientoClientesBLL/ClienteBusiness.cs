using MantenimientoClientes.DAL;
using MantenimientoClientesBOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenimientoClientesBLL
{
    public class ClienteBusiness
    {
        private ClienteDAO clienteDao;
        public ClienteBusiness() => clienteDao = new ClienteDAO();
        public long? InsertarActualizar(int? idcliente, string Apellido, string Nombre, string Dni, string Sexo, string Edad, string Nivelestudios, string Telefono)
        {
            long? id;
            Cliente c = new Cliente();
            c.idcliente = idcliente;
            c.Apellido = Apellido;
            c.Nombre = Nombre;
            c.Nivelestudios = Nivelestudios;
            c.Sexo = Sexo;
            c.Edad = Edad;
            c.Telefono = Telefono;
            c.Dni = Dni;
            id = clienteDao.InsertarActualizar(c);

            return id;
        }
        //public void Actualizar(Cliente cliente) => clienteDao.Actualizar(cliente);
        public void Eliminar(int? id) => clienteDao.Eliminar(id);
        public Cliente Obtener(int? id) => clienteDao.Obtener(id);
        public List<Cliente> Listar()
        {
            return clienteDao.Listar();
        }
        public List<Cliente> Listar(String condicion)
        {
            return clienteDao.Listar(condicion);
        }

    }
}
