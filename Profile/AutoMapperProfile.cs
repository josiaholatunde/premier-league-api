using Fixtures.API.DTOS;
using Fixtures.API.Models;

namespace Fixtures.API.Profile
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            //API REsource to DOmain Classes
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForLoginDto, User>();
            CreateMap<TeamToCreateDto, Team>()
            .ForMember(dest => dest.LocationCity, opt => opt.MapFrom(src => src.Location.City))
            .ForMember(dest => dest.LocationCountry, opt => opt.MapFrom(src => src.Location.Country));
            //Domain Classes to API Resource
            CreateMap<User, UserToReturnDto>();
            CreateMap<Team, TeamToReturnDto>();
        }
    }
}