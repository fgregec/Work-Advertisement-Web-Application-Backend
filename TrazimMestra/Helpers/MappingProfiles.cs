using AutoMapper;
using Core.Entities;
using TrazimMestra.Dtos;

namespace TrazimMestra.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Password, opt => opt.Condition(src => src.Password != null))
                .ForMember(dest => dest.City, opt => opt.Ignore())
                .ForMember(dest => dest.ListResolvedNatjecaja, opt => opt.Ignore());
        }
    }
}
