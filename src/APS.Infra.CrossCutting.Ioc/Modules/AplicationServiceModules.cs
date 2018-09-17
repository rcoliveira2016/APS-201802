using APS.Application.AppService;
using APS.Application.AutoMapper;
using APS.Application.Interfaces;
using AutoMapper;
using SimpleInjector;
using System;
using System.Linq;
using System.Reflection;

namespace APS.Infra.CrossCutting.Ioc.Modules
{
    public static class AplicationServiceModules
    {
        public static void Register(Container container)
        {
            AutoMapperRegistry(container);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
        }

        private static void AutoMapperRegistry(Container container)
        {

            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });


            container.Register<AutoMapper.IMapper>(() => config.CreateMapper(container.GetInstance), Lifestyle.Scoped);
        }
    }
}
