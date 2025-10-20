using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.SubAboutDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class SubAboutMapping : Profile
    {
        public SubAboutMapping()
        {
            CreateMap<SubAbout, SubAboutDto>().ReverseMap();
        }
    }
}
