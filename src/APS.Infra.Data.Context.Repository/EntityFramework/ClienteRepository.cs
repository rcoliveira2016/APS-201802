using APS.Domain.Interfaces.Repository.Usuario;
using APS.Domain.Models.Clientes;
using APS.Infra.Data.Context.Repository.EntityFramework.Usuario.Common;
using APS.Infra.Data.Core.Interfaces;

namespace APS.Infra.Data.Context.Repository.EntityFramework.Usuario
{
    public sealed class ClienteRepository : Repository<Cliente>, IClienteRepository
    {


        public ClienteRepository(IDbContext dbContext):base(dbContext)
        {
        }
       
        
    }
}
