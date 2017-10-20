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



        public ClienteBusiness()
        {
            clienteDao = new ClienteDAO();
        }



        public void insertar(Cliente cliente)
        {
            clienteDao.Insertar(cliente);
        }

        public void actualizar(Cliente cliente)
        {
            clienteDao.Actualizar(cliente);
        }

        public void eliminar(int? id)
        {
            clienteDao.Eliminar(id);
        }


        public Cliente obtener(int? id)
        {
            return clienteDao.Obtener(id);
        }

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
