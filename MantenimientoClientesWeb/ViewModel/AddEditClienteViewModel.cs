using MantenimientoClientesBLL;
using MantenimientoClientesBOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MantenimientoClientesWeb.ViewModel
{
   

    public class AddEditClienteViewModel
    {
        public int? ClienteId { get; set; }
        public string Apellido { get; set; }

  
        public string Nombre { get; set; }


        public string Dni { get; set; }

 
        public string Sexo { get; set; }


        public string Edad { get; set; }


        public string Nivelestudios { get; set; }

   
        public string Telefono { get; set; }

        public AddEditClienteViewModel()
        {
        }

        public void Fill(int? ClienteId)
        {
            this.ClienteId = ClienteId;
            if(ClienteId.HasValue)
            {
                ClienteBusiness dao = new ClienteBusiness();
                var objCliente = dao.Obtener(ClienteId);
                if (objCliente == null) return;
                this.Apellido = objCliente.Apellido;
                this.Dni = objCliente.Dni;
                this.Edad = objCliente.Edad;
                this.Nombre = objCliente.Nombre;
                this.Sexo = objCliente.Sexo;
                this.Nivelestudios = objCliente.Nivelestudios;
                this.Telefono = objCliente.Telefono;
            }
        }
    }

    public enum NivelEstudios
    {
        UNIVERSIDAD,
        INSTITUTO,
        COLEGIO
    }

}