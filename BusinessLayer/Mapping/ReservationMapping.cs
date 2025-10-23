using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class ReservationMapping : Profile
    {
        public ReservationMapping()
        {
            CreateMap<Reservation, ReservationDto>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                                                    .ReverseMap()
                                                    .ForMember(dest => dest.AppUser, opt => opt.Ignore());


        }
    }
}
