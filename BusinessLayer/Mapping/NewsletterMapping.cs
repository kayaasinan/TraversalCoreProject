using AutoMapper;
using DTOLayer.DTOs.AboutDTOs;
using DTOLayer.DTOs.NewsletterDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class NewsletterMapping : Profile
    {
        public NewsletterMapping()
        {
            CreateMap<Newsletter, NewsletterDto>().ReverseMap();
        }
    }
}
