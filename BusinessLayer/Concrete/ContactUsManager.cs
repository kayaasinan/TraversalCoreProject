using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace BusinessLayer.Concrete
{
    [AllowAnonymous]
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;
        private readonly IMapper _mapper;

        public ContactUsManager(IContactUsDal contactUsDal, IMapper mapper)
        {
            _contactUsDal = contactUsDal;
            _mapper = mapper;
        }

        public List<ContactUsDto> TGetListContactUsByFalse()
        {
            var entities=_contactUsDal.GetListContactUsByFalse();
            return _mapper.Map<List<ContactUsDto>>(entities);
        }

        public List<ContactUsDto> TGetListContactUsByTrue()
        {
            var entities = _contactUsDal.GetListContactUsByTrue();
            return _mapper.Map<List<ContactUsDto>>(entities);
        }

        public void TMessageToggleStatus(int id)
        {
            _contactUsDal.ToggleMessageStatus(id);
        }

        public void TAdd(ContactUsDto dto)
        {
            var entity = _mapper.Map<ContactUs>(dto);
            entity.Status = true;
            entity.Date = DateTime.Now;
            _contactUsDal.Insert(entity);
        }

        public void TDelete(ContactUsDto dto)
        {
            var entity = _mapper.Map<ContactUs>(dto);
            _contactUsDal.Delete(entity);
        }

        public ContactUsDto TGetById(int id)
        {
            var entity = _contactUsDal.GetById(id);
            return _mapper.Map<ContactUsDto>(entity);
        }

        public List<ContactUsDto> TGetList()
        {
            var entity=_contactUsDal.GetList();
            return _mapper.Map<List<ContactUsDto>>(entity);
        }

        public void TUpdate(ContactUsDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
