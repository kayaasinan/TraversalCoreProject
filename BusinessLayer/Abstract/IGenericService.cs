using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<TDto>
    {
        void TAdd(TDto dto);
        void TDelete(TDto dto);
        void TUpdate(TDto dto);
        List<TDto> TGetList();
        TDto TGetById(int id);

        //List<T> GetByFilter(Expression<Func<T, bool>> filter);
    }
}
