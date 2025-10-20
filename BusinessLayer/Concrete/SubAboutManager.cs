using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.SubAboutDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager : ISubAboutService
    {
        private readonly ISubAboutDal _subAboutDal;
        private readonly IMapper _mapper;

        public SubAboutManager(ISubAboutDal subAboutDal, IMapper mapper)
        {
            _subAboutDal = subAboutDal;
            _mapper = mapper;
        }

        public void TAdd(SubAboutDto dto)
        {
            var entity = _mapper.Map<SubAbout>(dto);
            _subAboutDal.Insert(entity);
        }

        public void TDelete(SubAboutDto dto)
        {
            var entity = _mapper.Map<SubAbout>(dto);
            _subAboutDal.Delete(entity);
        }

        public void TUpdate(SubAboutDto dto)
        {
            var entity = _mapper.Map<SubAbout>(dto);
            _subAboutDal.Update(entity);
        }

        public List<SubAboutDto> TGetList()
        {
            var entities = _subAboutDal.GetList();
            return _mapper.Map<List<SubAboutDto>>(entities);
        }

        public SubAboutDto TGetById(int id)
        {
            var entity = _subAboutDal.GetById(id);
            return _mapper.Map<SubAboutDto>(entity);
        }
    }
}
