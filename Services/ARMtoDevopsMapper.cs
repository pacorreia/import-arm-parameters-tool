using AutoMapper;
using Common.Dto.Template;
using Common.Dto.Devops;

namespace Services.Mappers
{
    public static class ARMtoDevopsMapper{
        public static VariableGroupRequestDto MapParametersToVariableGroupRequest(ParametersDto template)
        {
            MapperConfiguration MapperConfig = new(cfg => {
                cfg.CreateMap<ParametersDto,VariableGroupRequestDto>()
                    .ForMember(dest =>dest.Variables, act => act.MapFrom(sourceMember=> 
                        sourceMember.Parameters)
                    );
                cfg.CreateMap<ParameterValueDto,VariableGroupVariablesDto>();
            });

            Mapper mapper=new(MapperConfig);
            return mapper.Map<VariableGroupRequestDto>(template);
        }  
    }
}