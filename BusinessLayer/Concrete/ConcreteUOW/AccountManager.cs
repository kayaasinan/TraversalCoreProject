using AutoMapper;
using BusinessLayer.Abstract.AbstractUOW;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AccountDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete.ConcreteUOW
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUOWDal _uowDal;
        private readonly IMapper _mapper;

        public AccountManager(IAccountDal accountDal, IUOWDal uowDal, IMapper mapper)
        {
            _accountDal = accountDal;
            _uowDal = uowDal;
            _mapper = mapper;
        }

        public List<AccountDto> TGetAll()
        {
            var entities = _accountDal.GetAll();    
            return _mapper.Map<List<AccountDto>>(entities);
        }

        public AccountDto TGetById(int id)
        {
            var entity = _accountDal.GetById(id);
            return  _mapper.Map<AccountDto>(entity);
        }

        public void TInsert(AccountDto t)
        {
            var entity = _mapper.Map<Account>(t);
            _accountDal.Insert(entity);
            _uowDal.Save();
        }

        public void TMultiUpdate(List<AccountDto> t)
        {
            var entity = _mapper.Map<List<Account>>(t);
            _accountDal.MultiUpdate(entity);
            _uowDal.Save();
        }

        public void TUpdate(AccountDto t)
        {
            var entity = _mapper.Map<Account>(t);
            _accountDal.Update(entity);
            _uowDal.Save();
        }
    }
}
