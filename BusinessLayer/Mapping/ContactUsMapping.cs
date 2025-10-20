using AutoMapper;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class ContactUsMapping : Profile
    {
        public ContactUsMapping()
        {
            CreateMap<ContactUs, ContactUsDto>().ReverseMap();
        }
    }
}
