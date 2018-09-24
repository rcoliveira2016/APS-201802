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
       
        
    }
}
