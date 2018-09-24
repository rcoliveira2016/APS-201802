using APS.Application.ViewModel.Clientes;
using MvcMusicStore.Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        void Cadastrar(CadastroViewModel cadastroViewModel);
        void Remover(long id);
        ICollection<CadastroViewModel> BuscarTodos(bool ativos = false);
        void Atualizar(CadastroViewModel cadastroViewModel);
        CadastroViewModel BuscarPorId(long id);
    }
}
