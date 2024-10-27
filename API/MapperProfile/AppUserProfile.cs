using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.MapperProfile
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, UserDto>()
                .ForMember(d => d.Username, opt => opt.MapFrom(src => src.UserName));
            
            CreateMap<AppUser, MemberDto>()
                .ForMember(d => d.Age, o => o.MapFrom(s => s.DateOfBirth.CalculateAge()))
                .ForMember(d => d.PhotoUrl, o => 
                    o.MapFrom(s => s.Photo.FirstOrDefault(x => x.IsMain)!.URL));
            CreateMap<Photo, PhotoDto>();
        }
    }
}