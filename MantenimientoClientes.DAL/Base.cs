using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenimientoClientes.DAL
{
    public interface Base<T,p>
    {
        long? InsertarActualizar(T c);
        //void Actualizar(T e);
        void Eliminar(p id);
        T Obtener(p id);
        List<T> Listar();
        List<T> Listar(string apellido);
    }
}
