using APS.Domain.Core.Interface;
using APS.Domain.Interfaces.Repository.Usuario;
using APS.Infra.Data.Context.Config;
using APS.Infra.Data.Context.Repository.EntityFramework.Usuario;
using APS.Infra.Data.Context.Repository.EntityFramework.Usuario.Common;
using APS.Infra.Data.Core;
using APS.Infra.Data.Core.Config;
using APS.Infra.Data.Core.Interfaces;
using SimpleInjector;

namespace APS.Infra.CrossCutting.Ioc.Modules
{
    public sealed class RepositoryModules
    {
        public static void Register(Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IDbContext, APSContext>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
        }
    }
}
