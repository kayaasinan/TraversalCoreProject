using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;
        private readonly IMapper _mapper;

        public GuideManager(IGuideDal guideDal, IMapper mapper)
        {
            _guideDal = guideDal;
            _mapper = mapper;
        }
        public void TAdd(GuideDto dto)
        {
            var entity = _mapper.Map<Guide>(dto);
            _guideDal.Insert(entity);
        }

        public void TChangeStatus(int id)
        {
            _guideDal.ChangeGuideStatus(id);
        }

        public void TDelete(GuideDto dto)
        {
            var entity = _mapper.Map<Guide>(dto);
            _guideDal.Delete(entity);
        }

        public GuideDto TGetById(int id)
        {
            var entity = _guideDal.GetById(id);
            return _mapper.Map<GuideDto>(entity);
        }

        public List<GuideDto> TGetLast7Guide()
        {
            var entities= _guideDal.GetLast7Guide();
            return _mapper.Map<List<GuideDto>>(entities);
        }

        public List<GuideDto> TGetList()
        {
            var entities = _guideDal.GetList();
            return _mapper.Map<List<GuideDto>>(entities);
        }

        public void TUpdate(GuideDto dto)
        {
            var entity = _mapper.Map<Guide>(dto);
            _guideDal.Update(entity);
        }

    }
}
