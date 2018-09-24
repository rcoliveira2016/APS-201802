using APS.Domain.Core.Models.Common;
using APS.Domain.Models.Agendamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Models.Clientes
{
    public sealed class Cliente:Entity
    {

        public Cliente(){}

        public Cliente(long id)
        {
            Id = id;
        }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}
