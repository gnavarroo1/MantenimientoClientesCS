using MantenimientoClientesBOL;
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
        public int? AddEditCliente(int? idcliente, string Apellido, string Nombre, string Dni, string Sexo, string Edad, string Nivelestudios, string Telefono)
        {

            Cliente c = null;
            c = clienteDao.AddEditCliente(idcliente,Apellido,Nombre,Dni,Sexo,Edad,Nivelestudios,Telefono);

            return c != null ? c.idcliente : null;
        }
        //public void Actualizar(Cliente cliente) => clienteDao.Actualizar(cliente);
        public void Eliminar(int? id) => clienteDao.Eliminar(id);
        public Cliente Obtener(int? id) => clienteDao.Obtener(id);
        
        public List<Cliente> Listar(String condicion)
        {
            return clienteDao.Listar(condicion);
        }

    }
}
