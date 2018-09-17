using APS.Application.Interfaces;
using APS.Domain.Interfaces.Service;
using System;
using APS.Application.ViewModel.Usuario;
using AutoMapper;
using APS.Domain.Models.Usurios;
using System.Collections.Generic;
using System.Linq;

namespace APS.Application.AppService
{
    public sealed class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService usuarioService;
        private readonly IMapper mapper;
        public UsuarioAppService(IUsuarioService usuarioService, IMapper mapper)
        {
            this.usuarioService = usuarioService;
            this.mapper = mapper;
        }

        public ICollection<CadastroViewModel> BuscarTodos()
        {
            var lista = usuarioService.BuscarTodos();
            return mapper.Map<ICollection<CadastroViewModel>>(lista);
        }

        public void Cadastrar(CadastroViewModel cadastroViewModel)
        {
            var usuario = mapper.Map<Usuario>(cadastroViewModel);
            usuarioService.Cadastrar(usuario);
        }

        public void Atualizar(CadastroViewModel cadastroViewModel)
        {
            var usuario = mapper.Map<Usuario>(cadastroViewModel);
            usuarioService.Atualizar(usuario);
        }

        public CadastroViewModel BuscarPorId(long id)
        {
            return mapper.Map<CadastroViewModel>(
                usuarioService.BuscarPorId(id)
            );
        }

        public void Remover(long id)
        {
            usuarioService.Remover(id);
        }

        public void Dispose()
        {
            usuarioService.Dispose();
            GC.SuppressFinalize(this);
        }

        public CadastroViewModel BuscarPorLogin(string login)
        {
            return mapper.Map<CadastroViewModel>(
                usuarioService.BuscarTodos()
                    .FirstOrDefault(x=> x.Login.Equals(login))
            );
        }
    }
}
