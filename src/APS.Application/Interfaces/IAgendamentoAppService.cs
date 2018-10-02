using APS.Application.ViewModel.Agendamentos;
using MvcMusicStore.Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Application.Interfaces
{
    public interface IAgendamentoAppService : IDisposable
    {
        void Cadastrar(CadastroViewModel cadastroViewModel);
        void Remover(long id);
        ICollection<CadastroViewModel> BuscarTodos();
        ICollection<CadastroViewModel> BuscarPorDataMes(DateTime data);
        ICollection<CadastroViewModel> BuscarPorData(DateTime data);
        void Atualizar(CadastroViewModel cadastroViewModel);
        CadastroViewModel BuscarPorId(long id);
    }
}
