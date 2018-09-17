using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Infra.CrossCutting.Bus
{
    public static class InMemory
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor?.Invoke();
        
        public static TService GetService<TService>()
        {
            return (TService)Container.GetService(typeof(TService));
        }
    }
}
