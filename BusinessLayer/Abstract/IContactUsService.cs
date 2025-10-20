using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactUsService : IGenericService<ContactUsDto>
    {
        List<ContactUsDto> TGetListContactUsByTrue();
        List<ContactUsDto> TGetListContactUsByFalse();
        void TMessageToggleStatus(int id);
    }
}
