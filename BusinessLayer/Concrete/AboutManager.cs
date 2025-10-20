using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.AboutDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IMapper _mapper;

        public AboutManager(IAboutDal aboutDal, IMapper mapper)
        {
            _aboutDal = aboutDal;
            _mapper = mapper;
        }

        public void TAdd(AboutDto dto)
        {
            var entity = _mapper.Map<About>(dto);
            _aboutDal.Insert(entity);
        }

        public void TDelete(AboutDto dto)
        {
            var entity = _mapper.Map<About>(dto);
            _aboutDal.Delete(entity);
        }

        public void TUpdate(AboutDto dto)
        {
            var entity = _mapper.Map<About>(dto);
            _aboutDal.Update(entity);
        }

        public List<AboutDto> TGetList()
        {
            var entities = _aboutDal.GetList();
            return _mapper.Map<List<AboutDto>>(entities);
        }

        public AboutDto TGetById(int id)
        {
            var entity = _aboutDal.GetById(id);
            return _mapper.Map<AboutDto>(entity);
        }
    }
}
