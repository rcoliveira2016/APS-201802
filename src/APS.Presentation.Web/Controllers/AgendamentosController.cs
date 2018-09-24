using APS.Application.Interfaces;
using APS.Application.ViewModel.Agendamentos;
using APS.Presentation.Web.Controllers.Common;
using APS.Presentation.Web.Helpers.Attributes;
using System.Web.Mvc;

namespace APS.Presentation.Web.Controllers
{
    public class AgendamentosController : BaseController
    {
        private readonly IAgendamentoAppService agendamentoAppService;
        private readonly IClienteAppService clienteAppService;

        public AgendamentosController(IAgendamentoAppService agendamentoAppService, IClienteAppService clienteAppService)
        {
            this.agendamentoAppService = agendamentoAppService;
            this.clienteAppService = clienteAppService;
        }

        public ActionResult Index()
        {
            return View(agendamentoAppService.BuscarTodos());
        }

        public ActionResult Cadastrar()
        {
            CarregarCombos();
            return View(new CadastroViewModel { });
        }

        public ActionResult Atualizar(long id)
        {
            CarregarCombos();
            var viewModel = agendamentoAppService.BuscarPorId(id);
            return View("Cadastrar", viewModel);
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroViewModel cadastroViewModel)
        {
            agendamentoAppService.Cadastrar(cadastroViewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Atualizar(CadastroViewModel cadastroViewModel)
        {
            agendamentoAppService.Atualizar(cadastroViewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Excluir(long id)
        {
            agendamentoAppService.Remover(id);
            return new HttpStatusCodeResult(200);
        }

        private void CarregarCombos()
        {
            ViewBag.Clientes = clienteAppService.BuscarTodos(true);
        }
    }
}