using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGuideService : IGenericService<GuideDto>
    {
        void TChangeStatus(int id);
    }
}
