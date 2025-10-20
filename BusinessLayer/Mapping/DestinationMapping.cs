using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.DestinationDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class DestinationMapping:Profile
    {
        public DestinationMapping()
        {
            CreateMap<Destination, DestinationDto>().ReverseMap();
        }
    }
}
