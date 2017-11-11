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
        public void InsertarActualizar(Cliente cliente) => clienteDao.InsertarActualizar(cliente);
        public void Actualizar(Cliente cliente) => clienteDao.Actualizar(cliente);
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
