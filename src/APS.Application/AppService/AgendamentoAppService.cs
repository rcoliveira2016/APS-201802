using APS.Application.Interfaces;
using APS.Domain.Interfaces.Service;
using System;
using APS.Application.ViewModel.Agendamentos;
using AutoMapper;
using APS.Domain.Models.Usurios;
using System.Collections.Generic;
using System.Linq;
using APS.Domain.Models.Agendamentos;

namespace APS.Application.AppService
{
    public sealed class AgendamentoAppService : IAgendamentoAppService
    {
        private readonly IAgendamentoService agendamentoService;
        private readonly IMapper mapper;
        public AgendamentoAppService(IAgendamentoService AgendamentoService, IMapper mapper)
        {
            this.agendamentoService = AgendamentoService;
            this.mapper = mapper;
        }

        public ICollection<CadastroViewModel> BuscarTodos()
        {
            var lista = agendamentoService.BuscarTodos();
            return mapper.Map<ICollection<CadastroViewModel>>(lista);
        }

        public void Cadastrar(CadastroViewModel cadastroViewModel)
        {
            var agendamento = mapper.Map<Agendamento>(cadastroViewModel);
            agendamentoService.Cadastrar(agendamento);
        }

        public void Atualizar(CadastroViewModel cadastroViewModel)
        {
            var agendamento = mapper.Map<Agendamento>(cadastroViewModel);
            agendamentoService.Atualizar(agendamento);
        }

        public CadastroViewModel BuscarPorId(long id)
        {
            return mapper.Map<CadastroViewModel>(
                agendamentoService.BuscarPorId(id)
            );
        }

        public void Remover(long id)
        {
            agendamentoService.Remover(id);
        }

        public void Dispose()
        {
            agendamentoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
