using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.ContactUsDTOs;

namespace BusinessLayer.Concrete
{
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
            throw new NotImplementedException();
        }

        public void TDelete(ContactUsDto dto)
        {
            throw new NotImplementedException();
        }

        public ContactUsDto TGetById(int id)
        {
            throw new NotImplementedException();
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
