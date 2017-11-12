using MantenimientoClientesBLL;
using MantenimientoClientesBOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MantenimientoClientesWeb.ViewModel
{
    public class LstClienteViewModel
    {
        public List<Cliente> LstClientes { get; set; }
        public String Filtro { get; set; }
        
        public LstClienteViewModel()
        {
            Fill();
        }

        public void Fill()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            if(!String.IsNullOrEmpty(Filtro))
            {
                LstClientes = clienteBusiness.Listar(Filtro);
            }
            else
            {
                LstClientes = clienteBusiness.Listar();
            }

        }
    }
}