using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class AppUserMapping:Profile
    {
        public AppUserMapping()
        {
            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                                            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                                            .ReverseMap();
        }
    }
}
