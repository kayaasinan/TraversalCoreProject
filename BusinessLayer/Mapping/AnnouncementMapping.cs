using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Mapping
{
    public class AnnouncementMapping : Profile
    {
        public AnnouncementMapping()
        {
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
        }
    }
}
