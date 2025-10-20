using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.Feature2DTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class Feature2Mapping : Profile
    {
        public Feature2Mapping()
        {
            CreateMap<Feature2, Feature2Dto>().ReverseMap();
        }
    }
}
