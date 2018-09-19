using APS.Application.Interfaces;
using APS.Domain.Interfaces.Service;
using System;
using APS.Application.ViewModel.Clientes;
using AutoMapper;
using APS.Domain.Models.Usurios;
using System.Collections.Generic;
using System.Linq;
using APS.Domain.Models.Clientes;

namespace APS.Application.AppService
{
    public sealed class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService clienteService;
        private readonly IMapper mapper;
        public ClienteAppService(IClienteService clienteService, IMapper mapper)
        {
            this.clienteService = clienteService;
            this.mapper = mapper;
        }

        public ICollection<CadastroViewModel> BuscarTodos()
        {
            var lista = clienteService.BuscarTodos();
            return mapper.Map<ICollection<CadastroViewModel>>(lista);
        }

        public void Cadastrar(CadastroViewModel cadastroViewModel)
        {
            var cliente = mapper.Map<Cliente>(cadastroViewModel);
            clienteService.Cadastrar(cliente);
        }

        public void Atualizar(CadastroViewModel cadastroViewModel)
        {
            var cliente = mapper.Map<Cliente>(cadastroViewModel);
            clienteService.Atualizar(cliente);
        }

        public CadastroViewModel BuscarPorId(long id)
        {
            return mapper.Map<CadastroViewModel>(
                clienteService.BuscarPorId(id)
            );
        }

        public void Remover(long id)
        {
            clienteService.Remover(id);
        }

        public void Dispose()
        {
            clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
