using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUserDto>
    {
        Task<AppUserDto> TGetByIdAsync(int id);

    }
}
