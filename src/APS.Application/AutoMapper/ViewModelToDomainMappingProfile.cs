using APS.Application.AutoMapper.Mapping;
using APS.Infra.CrossCutting.Bus;
using AutoMapper;

namespace APS.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public IMapper Mapper { get => InMemory.GetService<IMapper>(); }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            UsuarioMap.Map(this);
            ClienteMap.Map(this);
            Common.Map(this);
        }
    }
}