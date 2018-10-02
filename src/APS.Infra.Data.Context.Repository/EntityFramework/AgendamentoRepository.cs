using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using APS.Domain.Interfaces.Repository.Usuario;
using APS.Domain.Models.Agendamentos;
using APS.Infra.Data.Context.Repository.EntityFramework.Usuario.Common;
using APS.Infra.Data.Core.Interfaces;

namespace APS.Infra.Data.Context.Repository.EntityFramework.Usuario
{
    public sealed class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {


        public AgendamentoRepository(IDbContext dbContext):base(dbContext)
        {
        }

        public ICollection<Agendamento> BuscarPorData(DateTime data)
        {
            return Find(x => EntityFunctions.TruncateTime(x.Data) == data.Date).ToList();
        }
    }
}
