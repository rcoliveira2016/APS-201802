using APS.Application.Interfaces;
using APS.Application.ViewModel.Clientes;
using APS.Presentation.Web.Helpers.Attributes;
using System.Web.Mvc;

namespace APS.Presentation.Web.Controllers
{
    [AutenticacaoWebMVC]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            this.clienteAppService = clienteAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}