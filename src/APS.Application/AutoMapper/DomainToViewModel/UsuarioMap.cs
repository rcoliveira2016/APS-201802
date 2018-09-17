using APS.Application.ViewModel.Common;
using APS.Application.ViewModel.Usuario;
using APS.Domain.Models.Usurios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Application.AutoMapper.DomainToViewModel
{
    public sealed class UsuarioMap
    {
        public static void Map(DomainToViewModelMappingProfile profile)
        {
            profile.CreateMap<Usuario, CadastroViewModel>();

            profile.CreateMap<ArquivoUsuario, AnexoViewModel>()
               .ForMember(x => x.Arquivo, m => m.MapFrom(o => Convert.ToBase64String(o.Arquivo.Conteudo)))
               .ForMember(x => x.Nome, m => m.MapFrom(o => o.Arquivo.Nome));
        }
    }
}
