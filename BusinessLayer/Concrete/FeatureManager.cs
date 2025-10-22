using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.FeatureDTOs;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;
        private readonly IMapper _mapper;


        public FeatureManager(IFeatureDal featureDal, IMapper mapper)
        {
            _featureDal = featureDal;
            _mapper = mapper;
        }

        public void TAdd(FeatureDto dto)
        {
            var entity = _mapper.Map<Feature>(dto);
            _featureDal.Insert(entity);
        }

        public void TDelete(FeatureDto dto)
        {
            var entity = _mapper.Map<Feature>(dto);
            _featureDal.Delete(entity);
        }

        public FeatureDto TGetById(int id)
        {
            var entity = _featureDal.GetById(id);
            return _mapper.Map<FeatureDto>(entity);
        }

        public List<FeatureDto> TGetList()
        {
            var entities = _featureDal.GetList();
            return _mapper.Map<List<FeatureDto>>(entities);
        }

        public void TUpdate(FeatureDto dto)
        {
            var entity = _mapper.Map<Feature>(dto);
            _featureDal.Update(entity);
        }
    }
}
