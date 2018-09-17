using APS.Application.ViewModel.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Application.Interfaces
{
    interface ISessionContext
    {
        void SalvarUsuarioLogado(CadastroViewModel model);
        CadastroViewModel RetornarUsuarioLogado();        
    }
}
