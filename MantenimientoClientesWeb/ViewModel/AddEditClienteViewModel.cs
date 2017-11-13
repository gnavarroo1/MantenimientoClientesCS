using MantenimientoClientesBLL;
using MantenimientoClientesBOL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MantenimientoClientesWeb.ViewModel
{
   

    public class AddEditClienteViewModel
    {
        public int? ClienteId { get; set; }

        [Required(ErrorMessage = "Falto llenar el campo Apellido")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Error. Caracteres no validos")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Falto llenar el campo Nombre")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Error. Caracteres no validos")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Falto llenar el campo DNI")]
        [RegularExpression(@"^([0-9]{8})$", ErrorMessage = "Numero de DNI invalido")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Sexo")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Falto llenar el campo Edad")]
        [Range(18, 70, ErrorMessage = "La edad ingresada no se encuentra en el rango permitido")]
        [RegularExpression(@"^([0-9]{1,2})$", ErrorMessage = "Edad invalida")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "Debe de seleccionar su nivel de estudios")]
        public string Nivelestudios { get; set; }

        [Required(ErrorMessage = "Falto llenar el campo Telefono")]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Numero de telefono invalido")]
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