using System;
using NUnit.Framework;
using MantenimientoClientesBLL;
using MantenimientoClientesBOL.Models;
using System.Collections.Generic;
using MantenimientoClientes.DAL;

namespace MantenimientoClientesTest
{

    public class ClienteTest
    {
        private static ClienteBusiness clienteBusiness = new ClienteBusiness();
        private Cliente cliente = new Cliente();
        private void init()
        {
            DataAccess da = new DataAccess();
            da.TruncateTable();
        }

        private bool Compare(Cliente a, Cliente b)
        {
            return (a.Apellido == b.Apellido) && (a.Nombre == b.Nombre) && (a.Edad == b.Edad ) && ( a.Dni == b.Dni) && (a.Nivelestudios == b.Nivelestudios) && (a.Sexo == b.Sexo) && (a.Telefono == b.Telefono) && (a.idcliente == b.idcliente);
            
        }

        [Test, Order(1)]
        [TestCase("TestInsertar", "TestInsertar", "12341234", "FEMENINO", "23", "INSTITUTO", "123412345", TestName ="Insertar")]
        public void insertar(String apellidoInsertar, String nombreInsertar, String dniInsertar, String sexoInsertar,
            String edadInsertar, String nivelestudiosInsertar, String telefonoInsertar)
        {
            this.init();
            try
            {

                Console.WriteLine("Metodo Insertar");
                long? id = clienteBusiness.InsertarActualizar(null, apellidoInsertar, nombreInsertar, dniInsertar, sexoInsertar, edadInsertar, nivelestudiosInsertar, telefonoInsertar);
                cliente.idcliente = (int?)id;
                Assert.True(id > 0);
            }
            catch (Exception e)
            {

                throw (e);
            }
        }

        [Test, Order(2)]
        [TestCase(TestName = "Actualizar")]
        public void actualizar()
        {

            try
            {
                Console.WriteLine("Metodo Actualizar");
                string Apellido = ("Actualizada");
                string Nombre = ("Actualizada");
                string Dni = ("11111111");
                string Sexo = ("MASCULINO");
                string Edad = ("11");
                string Nivelestudios = ("UNIVERSIDAD");
                string Telefono = ("222111333");
                long? id = clienteBusiness.InsertarActualizar(cliente.idcliente, Apellido, Nombre, Dni, Sexo, Edad, Nivelestudios, Telefono);
                cliente = new Cliente((int?)id, Apellido, Nombre, Dni, Sexo, Edad, Nivelestudios, Telefono);
                Assert.True(cliente.idcliente > 0);
            }
            catch (Exception e)
            {
                throw (e);

            }
        }

        [Test, Order(3)]
        [TestCase(TestName = "Obtener")]
        public void obtener()
        {
            try
            {

                Cliente c = clienteBusiness.Obtener(cliente.idcliente);

                Assert.True(Compare(cliente, c));
            }
            catch (Exception e)
            {
                throw (e);

            }
        }

        [Test, Order(5)]
        [TestCase(TestName = "Eliminar")]
        public void eliminar()
        {
            try
            {
                Console.WriteLine("Metodo Eliminar");
                clienteBusiness.Eliminar(cliente.idcliente);
                Cliente c = clienteBusiness.Obtener(cliente.idcliente);
                Assert.True(c == null);
            }
            catch (Exception e)
            {
                throw (e);
                // Assert.Fail();
            }
        }
        [Test, Order(4)]
        [TestCase(TestName = "Listar")]
        public void listar()
        {
            try
            {
                List<Cliente> clientes = null;
                Console.WriteLine("Metodo Listar");
                clientes = clienteBusiness.Listar();

                Assert.True(clientes != null);
            }
            catch (Exception e)
            {
                throw (e);
                // Assert.Fail();
            }
        }


    }
}
