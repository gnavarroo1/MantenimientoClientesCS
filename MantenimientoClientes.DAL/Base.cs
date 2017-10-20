using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenimientoClientes.DAL
{
    public interface Base<T,p>
    {
        void Insertar(T e);
        void Actualizar(T e);
        void Eliminar(p id);
        T Obtener(p id);
        List<T> Listar();
        List<T> Listar(String apellido);
    }
}
