using APS.Application.Interfaces;
using APS.Domain.Interfaces.Service;
using System;
using APS.Application.ViewModel.Agendamentos;
using AutoMapper;
using APS.Domain.Models.Usurios;
using System.Collections.Generic;
using System.Linq;
using APS.Domain.Models.Agendamentos;
using APS.Infra.CrossCutting.Util.Extencions;
using APS.Domain.Interfaces.Repository.Usuario;

namespace APS.Application.AppService
{
    public sealed class AgendamentoAppService : IAgendamentoAppService
    {
        private readonly IAgendamentoService agendamentoService;
        private readonly IAgendamentoRepository agendamentoRepository;
        private readonly IMapper mapper;
        public AgendamentoAppService(IAgendamentoService AgendamentoService, IAgendamentoRepository agendamentoRepository, IMapper mapper)
        {
            this.agendamentoService = AgendamentoService;
            this.agendamentoRepository = agendamentoRepository;
            this.mapper = mapper;
        }

        public ICollection<CadastroViewModel> BuscarTodos()
        {
            var lista = agendamentoService.BuscarTodos();
            return mapper.Map<ICollection<CadastroViewModel>>(lista);
        }

        public ICollection<CadastroViewModel> BuscarPorDataMes(DateTime data)
        {
            var dataAnteriorPrimeiroDia = data.FirstDayMonth().AddDays(-6);
            var dataDepoisUltimoDia = data.LastDayMonth().AddDays(6);
            var lista = agendamentoService.BuscarTodos(x=> x.Data> dataAnteriorPrimeiroDia && x.Data < dataDepoisUltimoDia) ?? Enumerable.Empty<Agendamento>();
            return mapper.Map<ICollection<CadastroViewModel>>(lista);
        }

        public ICollection<CadastroViewModel> BuscarPorData(DateTime data)
        {
            var lista = agendamentoRepository.BuscarPorData(data);
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
