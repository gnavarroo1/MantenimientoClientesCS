using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MantenimientoClientesWeb.Bean
{
    public class UsuarioBean
    {
        private String correo { get; set; }
        private String clave { get; set; }

        public UsuarioBean()
        {

        }

        public UsuarioBean(string correo, string clave)
        {
            this.correo = correo;
            this.clave = clave;
        }

        public override bool Equals(object obj)
        {
            var bean = obj as UsuarioBean;
            return bean != null &&
                   correo == bean.correo &&
                   clave == bean.clave;
        }

        public void init()
        {
            this.correo = "admin";
            this.clave = "clave";
        }
    }
}