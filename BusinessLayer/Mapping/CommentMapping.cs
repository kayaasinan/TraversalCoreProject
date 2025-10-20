using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.CommentDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class CommentMapping:Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, CommentDto>()
             .ForMember(dest => dest.DestinationCity, opt => opt.MapFrom(src => src.Destination.City)).ReverseMap()
             .ForPath(dest => dest.Destination.City, opt => opt.Ignore());
        }
    }
}
