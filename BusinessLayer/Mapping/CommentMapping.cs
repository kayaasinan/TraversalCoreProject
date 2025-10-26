using AutoMapper;
using DTOLayer.DTOs.CommentDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Mapping
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, CommentDto>().ForMember(dest => dest.AppUserImageUrl, opt => opt.MapFrom(src => src.AppUser.ImageUrl))
                                            .ReverseMap()
                                            .ForMember(dest => dest.AppUser, opt => opt.Ignore());


        }
    }
}
