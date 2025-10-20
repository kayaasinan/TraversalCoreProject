using AutoMapper;
using DTOLayer.DTOs.About2DTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Mapping
{
    public class About2Mapping:Profile
    {
        public About2Mapping()
        {
            CreateMap<About2, About2Dto>().ReverseMap();
        }
    }
}
