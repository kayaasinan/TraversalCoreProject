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
        private readonly IAnnouncementDal announcementDal;
        private readonly IMapper _mapper;

        public AnnouncementManager(IAnnouncementDal announcementDal, IMapper mapper)
        {
            this.announcementDal = announcementDal;
            _mapper = mapper;
        }

        public void TAdd(AnnouncementDto dto)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AnnouncementDto dto)
        {
            throw new NotImplementedException();
        }

        public AnnouncementDto TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AnnouncementDto> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AnnouncementDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
