using APS.Application.Interfaces;
using APS.Application.ViewModel.Usuario;
using APS.Domain.Core.Models.Usurios;
using APS.Presentation.Web.Controllers.Common;
using APS.Presentation.Web.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace APS.Presentation.Web.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IUsuarioAppService _serviceUsuarios;
        private readonly IAgendamentoAppService _agendamentoAppService;

        public HomeController(IUsuarioAppService serviceUsuarios, IAgendamentoAppService agendamentoAppService)
        {
            _serviceUsuarios = serviceUsuarios;
            _agendamentoAppService = agendamentoAppService;
        }

        
        public ActionResult Index()
        {            
            return View(_agendamentoAppService.BuscarPorData(DateTime.Now));
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

        [HttpGet]
        public ActionResult LogOff() {

            AplicacaoWeb.LogOffUsuario();
            return RedirectToAction("Login");
        }
        
    }
}