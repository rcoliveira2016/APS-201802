﻿using APS.Application.Interfaces;
using APS.Application.ViewModel.Clientes;
using APS.Presentation.Web.Controllers.Common;
using APS.Presentation.Web.Helpers.Attributes;
using System.Web.Mvc;

namespace APS.Presentation.Web.Controllers
{
    public class ClientesController : BaseController
    {        

        private readonly IClienteAppService clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            this.clienteAppService = clienteAppService;
        }

        public ActionResult Index()
        {
            return View(clienteAppService.BuscarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View(new CadastroViewModel { Ativo=true});
        }

        public ActionResult Atualizar(long id)
        {
            var viewModel = clienteAppService.BuscarPorId(id);
            return View("Cadastrar", viewModel);
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroViewModel cadastroViewModel)
        {
            clienteAppService.Cadastrar(cadastroViewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Atualizar(CadastroViewModel cadastroViewModel)
        {
            clienteAppService.Atualizar(cadastroViewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Excluir(long id)
        {
            clienteAppService.Remover(id);
            return new HttpStatusCodeResult(200);
        }

        [HttpGet]
        public JsonResult BurcarCliente(long id)
        {
            var cliente = clienteAppService.BuscarPorId(id);
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }
    }
}