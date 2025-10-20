using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        private readonly IMapper _mapper;

        public AppUserManager(IAppUserDal appUserDal, IMapper mapper)
        {
            _appUserDal = appUserDal;
            _mapper = mapper;
        }

        public void TAdd(AppUserDto dto)
        {
            var entity = _mapper.Map<AppUser>(dto);
            _appUserDal.Insert(entity);
        }

        public void TDelete(AppUserDto dto)
        {
            var entity = _mapper.Map<AppUser>(dto);
            _appUserDal.Delete(entity);
        }

        public void TUpdate(AppUserDto dto)
        {
            var entity = _mapper.Map<AppUser>(dto);
            _appUserDal.Update(entity);
        }

        public List<AppUserDto> TGetList()
        {
            var entities = _appUserDal.GetList();
            return _mapper.Map<List<AppUserDto>>(entities);
        }

        public AppUserDto TGetById(int id)
        {
            var entity = _appUserDal.GetById(id);
            return _mapper.Map<AppUserDto>(entity);
        }
    }
}
