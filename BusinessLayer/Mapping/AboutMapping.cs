using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
                CreateMap<About,AboutDto>().ReverseMap();
        }
    }
}
