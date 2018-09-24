using APS.Application.AutoMapper.Mapping;
using APS.Infra.CrossCutting.Bus;
using AutoMapper;

namespace APS.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public IMapper Mapper { get => InMemory.GetService<IMapper>(); }

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            AgendamentoMap.Map(this);
            UsuarioMap.Map(this);
            ClienteMap.Map(this);
        }
    }
}