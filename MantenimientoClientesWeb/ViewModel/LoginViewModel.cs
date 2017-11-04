using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MantenimientoClientesWeb.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Falto llenar el campo Usuario")]
        public String NombreUsuario { get; set; }
        [Required(ErrorMessage = "Falto llenar el campo Contraseña")]
        public String Contraseña { get; set; }

        public LoginViewModel()
        {

        }
    }
}