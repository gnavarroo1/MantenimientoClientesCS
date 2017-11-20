using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenimientoClientesSeleniumTests.Selenium.TestDataAccess
{
    public class ClienteBean : IContainer
    { 
        public string Key { get; set; }
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Sexo { get; set; }


        public string Edad { get; set; }


        public string Nivelestudios { get; set; }

        public string Telefono { get; set; }

        public string Resultado { get; set; }

        public ComponentCollection Components => throw new NotImplementedException();

        public void Add(IComponent component)
        {
            throw new NotImplementedException();
        }

        public void Add(IComponent component, string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ClienteBean GetThis()
        {
            return this;
        }

        public void Remove(IComponent component)
        {
            throw new NotImplementedException();
        }
    }
}
