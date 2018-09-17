using APS.Application.ViewModel.Common;
using APS.Domain.Models.Common.Anexos;
using APS.Domain.Models.Usurios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Application.AutoMapper.ViewModelToDomain
{
    public sealed class Common
    {
        public static void Map(ViewModelToDomainMappingProfile profile)
        {
            profile.CreateMap<AnexoViewModel, ArquivoUsuario>()
                .ConvertUsing(x =>                    
                    ArquivoUsuario.CriarUpload(
                            x.Id,
                            x.Nome,
                            string.IsNullOrEmpty(x.Arquivo) ?
                                null : Convert.FromBase64String(x.Arquivo)
                        )
                );
        }
    }
}
