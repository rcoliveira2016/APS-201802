using APS.Domain.Interfaces.Service;
using APS.Domain.Service;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Infra.CrossCutting.Ioc.Modules
{
    public static class ServiceModules
    {
        public static void Register(Container container)
        {
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
        }
    }
}
