using APS.Application.ViewModel.Common;
using APS.Application.ViewModel.Agendamentos;
using APS.Domain.Models.Common.Anexos;
using APS.Domain.Models.Agendamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace APS.Application.AutoMapper.Mapping
{
    public sealed class AgendamentoMap
    {
        public static void Map(ViewModelToDomainMappingProfile profile)
        {
            profile.CreateMap<CadastroViewModel, Agendamento>()
                .ForMember(x=> x.Data, m=> m.MapFrom(y=> DateTime.Parse(y.Data)))
                .ForMember(x=> x.HoraInicial, m=> m.MapFrom(y=> DateTime.ParseExact(y.HoraInicial, "HH:mm", CultureInfo.InvariantCulture)))
                .ForMember(x=> x.HoraFinal, m=> m.MapFrom(y=> DateTime.ParseExact(y.HoraFinal, "HH:mm", CultureInfo.InvariantCulture)));
        }

        public static void Map(DomainToViewModelMappingProfile profile)
        {
            profile.CreateMap<Agendamento, CadastroViewModel>()
                .ForMember(x => x.Cliente, m => m.MapFrom(y => y.Cliente.Nome))
                .ForMember(x => x.Data, m => m.MapFrom(y => y.Data.ToString("dd/MM/yyyy")))
                .ForMember(x => x.DataNumero, m => m.MapFrom(y => y.Data.ToString("yyyy-MM-ddTHH:mm:ss")))
                .ForMember(x => x.HoraInicial, m => m.MapFrom(y => y.HoraInicial.ToString("HH:mm")))
                .ForMember(x => x.HoraFinal, m => m.MapFrom(y => y.HoraFinal.ToString("HH:mm")));
        }
    }
}
