using AutoMapper;
using DTOLayer.DTOs.AccountDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class AccountMapping : Profile
    {
        public AccountMapping()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}
