using APS.Domain.Core.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Domain.Interfaces.Repository.Usuario
{
    public interface IAgendamentoRepository : IRepository<Models.Agendamentos.Agendamento>
    {

        ICollection<Models.Agendamentos.Agendamento> BuscarPorData(DateTime data);
    }
}
