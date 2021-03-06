﻿
using MantenimientoClientesBLL;
using MantenimientoClientesBOL.Models;
using MantenimientoClientesWeb.Bean;
using MantenimientoClientesWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace MantenimientoClientesWeb.Controllers
{
    public class HomeController : Controller
    {
        
        Boolean sessionOpen()
        {
            return Session["objUsuario"] != null;
        }
        public ActionResult Index()
        {           
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel objViewModel = new LoginViewModel();
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel objViewModel)
        {
            UsuarioBean clienteBean = new UsuarioBean();
            clienteBean.init();
            if (ModelState.IsValid)
            {
                try
                {
                    if (clienteBean.Equals(new UsuarioBean(objViewModel.NombreUsuario, objViewModel.Contraseña)))
                    {
                        Session["objUsuario"] = clienteBean;//Guardar los datos en la sesion
                        return RedirectToAction("LstCliente");
                    }
                    else
                    {
                        ViewBag.Error = "Usuario y/o contraseña incorrecta ";
                        return View(objViewModel);
                    }

                }
                catch (Exception)
                {
                    return View(objViewModel);
                }
            }
            else
            {
                ViewBag.Mensaje = "";
                return View(objViewModel);
            }
        }


        [HttpGet]
        public ActionResult AddEditCliente(int? ClienteId)
        {
            if (!sessionOpen()) return RedirectToAction("Login");
            AddEditClienteViewModel objViewModel = new AddEditClienteViewModel();
            objViewModel.Fill(ClienteId);
            return View(objViewModel);
        }


        [HttpPost]
        public ActionResult AddEditCliente(AddEditClienteViewModel objViewModel)
        {
            if (!sessionOpen()) return RedirectToAction("Login");
            if (ModelState.IsValid)
            {
                try
                {
                    ClienteBusiness clienteDAO = new ClienteBusiness();
                    clienteDAO.AddEditCliente(objViewModel.ClienteId,objViewModel.Apellido,objViewModel.Nombre,objViewModel.Dni,objViewModel.Sexo,objViewModel.Edad, objViewModel.Nivelestudios,objViewModel.Telefono);
                    ViewBag.Success = "Cliente Agregado con Exito";
                    ModelState.Clear();
                    return View(objViewModel);
                }
                catch (Exception)
                {
                    Console.Write("Error");
                    return View(objViewModel);
                }
            }
            else
                return View(objViewModel);
        }

        [HttpGet]
        public ActionResult LstCliente()
        {
            if (!sessionOpen()) return RedirectToAction("Login");
            LstClienteViewModel objViewModel = new LstClienteViewModel();
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult LstCliente(LstClienteViewModel objViewModel)
        {
            if (!sessionOpen()) return RedirectToAction("Login");
            objViewModel.Fill();
            return View(objViewModel);
        }
        public ActionResult DeleteCliente(int? ClienteId)
        {
            if (!sessionOpen()) return RedirectToAction("Login");
            try
            {
                ClienteBusiness dao = new ClienteBusiness();
                dao.Eliminar(ClienteId);
                ViewBag.DeleteConfirmation = " Cliente Eliminado con Exito ";
                return RedirectToAction("LstCliente");
            }
            catch (Exception)
            {
                return RedirectToAction("LstCliente");
            }
        }

    }
}