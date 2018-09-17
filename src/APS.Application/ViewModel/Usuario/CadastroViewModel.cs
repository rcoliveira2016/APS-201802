using APS.Application.ViewModel.Common;
using APS.Domain.Core.Models.Usurios;
using APS.Domain.Models.Usurios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Application.ViewModel.Usuario
{
    public sealed class CadastroViewModel
    {

        public CadastroViewModel(){}

        public long Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public eTipoUsuario TipoUsuario { get; set; }

        public bool EstaLogado { get; set; }
    }
}
