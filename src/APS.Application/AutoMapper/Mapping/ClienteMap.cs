using APS.Application.ViewModel.Common;
using APS.Application.ViewModel.Clientes;
using APS.Domain.Models.Common.Anexos;
using APS.Domain.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Application.AutoMapper.Mapping
{
    public sealed class ClienteMap
    {
        public static void Map(ViewModelToDomainMappingProfile profile)
        {
            profile.CreateMap<CadastroViewModel, Cliente>()
                .ForMember(x=> x.Agendamentos, m=> m.Ignore());
        }

        public static void Map(DomainToViewModelMappingProfile profile)
        {
            profile.CreateMap<Cliente, CadastroViewModel>();
        }
    }
}
