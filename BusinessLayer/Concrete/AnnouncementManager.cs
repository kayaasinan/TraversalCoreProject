using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;
        private readonly IMapper _mapper;

        public AnnouncementManager(IAnnouncementDal announcementDal, IMapper mapper)
        {
            _announcementDal = announcementDal;
            _mapper = mapper;
        }

        public void TAdd(AnnouncementDto dto)
        {
            var entity=_mapper.Map<Announcement>(dto);
            _announcementDal.Insert(entity);
        }

        public void TDelete(AnnouncementDto dto)
        {
            var entity=_mapper.Map<Announcement>(dto);
            _announcementDal.Delete(entity);
        }

        public AnnouncementDto TGetById(int id)
        {
            var entity=_announcementDal.GetById(id);
            return _mapper.Map<AnnouncementDto>(entity);
        }

        public List<AnnouncementDto> TGetList()
        {
           var entity=_announcementDal.GetList();
            return _mapper.Map<List<AnnouncementDto>>(entity);
        }

        public void TUpdate(AnnouncementDto dto)
        {
            var entity = _mapper.Map<Announcement>(dto);
            _announcementDal.Update(entity);
        }
    }
}
