using APS.Application.Interfaces;
using APS.Application.ViewModel.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace APS.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUsuarioAppService _serviceUsuarios;

        public HomeController(IUsuarioAppService serviceUsuarios)
        {
            _serviceUsuarios = serviceUsuarios;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUsuarioViewModel model)
        {
            var usuario = _serviceUsuarios.BuscarPorLogin(model.Login);
            if (usuario != null && usuario.Senha.Equals(model.Senha) && usuario.Login.Equals(model.Login))
            {
                AplicacaoWeb.LogarUsuario(usuario);
                return View("Index");
            }
            else
            {
                ViewBag.Erros = "Usuario ou senha Inválido!";
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult LogOff() {

            AplicacaoWeb.LogOffUsuario();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        
    }
}