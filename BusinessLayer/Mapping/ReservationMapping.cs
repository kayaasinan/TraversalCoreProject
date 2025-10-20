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
            CreateMap<Reservation, ReservationDto>().ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.AppUser.UserName))
                                                    .ForMember(dest => dest.DestinationCity, opt => opt.MapFrom(src => src.Destination.City))
                                                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
