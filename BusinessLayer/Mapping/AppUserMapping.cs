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
            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name + " " + src.SurName))
            .ReverseMap();
        }
    }
}
