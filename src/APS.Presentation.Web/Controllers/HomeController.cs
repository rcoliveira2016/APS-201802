using APS.Application.Interfaces;
using APS.Application.ViewModel.Usuario;
using APS.Domain.Core.Models.Usurios;
using APS.Presentation.Web.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace APS.Presentation.Web.Controllers
{
    [AutenticacaoWebMVC]
    public class HomeController : Controller
    {

        private readonly IUsuarioAppService _serviceUsuarios;

        public HomeController(IUsuarioAppService serviceUsuarios)
        {
            _serviceUsuarios = serviceUsuarios;
        }

        
        public ActionResult Index()
        {
            //AplicacaoWeb.LogarUsuario(new CadastroViewModel { Email = "tes@com.com", Id = 0, Login = "llo", Nome = "Luis Cesar", Senha = "123", TipoUsuario = eTipoUsuario.Administrador });
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("~/Views/Shared/_Login.cshtml");
        }
        

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginUsuarioViewModel model)
        {
            var usuario = _serviceUsuarios.BuscarPorLogin(model.Login);
            if (usuario != null && usuario.Senha.Equals(model.Senha) && usuario.Login.Equals(model.Login))
            {
                AplicacaoWeb.LogarUsuario(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erros = "Usuario ou senha Inválido!";
                return View("~/Views/Shared/_Login.cshtml");
            }
        }

        [HttpPost]
        public ActionResult LogOff() {

            AplicacaoWeb.LogOffUsuario();
            return View("~/Views/Shared/_Login.cshtml");
        }
        
    }
}