using APS.Application.Interfaces;
using APS.Presentation.Web.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APS.Presentation.Web.Controllers
{
    public class CalendarioController : BaseController
    {
        private readonly IAgendamentoAppService agendamentoAppService;

        public CalendarioController(IAgendamentoAppService agendamentoAppService)
        {
            this.agendamentoAppService = agendamentoAppService;
        }

        public ActionResult Index()
        {
            var lista = agendamentoAppService.BuscarPorDataMes(DateTime.Now);
            return View(lista);
        }

        [HttpGet]
        public JsonResult BuscarPorDataMes(DateTime data)
        {
            var lista = agendamentoAppService.BuscarPorDataMes(data);
            return Json(lista,JsonRequestBehavior.AllowGet);
        }
    }
}