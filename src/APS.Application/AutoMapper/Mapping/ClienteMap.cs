using APS.Application.ViewModel.Common;
using APS.Application.ViewModel.Usuario;
using APS.Domain.Models.Common.Anexos;
using APS.Domain.Models.Usurios;
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
            profile.CreateMap<CadastroViewModel, Usuario>();
        }

        public static void Map(DomainToViewModelMappingProfile profile)
        {
            profile.CreateMap<Usuario, CadastroViewModel>();
        }
    }
}
