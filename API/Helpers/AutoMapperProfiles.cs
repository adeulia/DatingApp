using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Map from - Map too
            //when mapping an individual prop, give it a destination prop, tell it where map from and source of the mapping
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(mapExpression: src => src.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<Photo, PhotoDto>();
        }
    }
}
