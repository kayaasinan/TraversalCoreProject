using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserDal _appUserDal;
        private readonly IMapper _mapper;

        public AppUserManager(IAppUserDal appUserDal, IMapper mapper, UserManager<AppUser> userManager)
        {
            _appUserDal = appUserDal;
            _mapper = mapper;
            _userManager = userManager;
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

        public async Task<AppUserDto> TGetByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<AppUserDto>(user);

        }
    }
}
