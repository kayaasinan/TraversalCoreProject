using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class GuideMapping : Profile
    {
        public GuideMapping()
        {
            CreateMap<Guide, GuideDto>().ReverseMap();
        }
    }
}
