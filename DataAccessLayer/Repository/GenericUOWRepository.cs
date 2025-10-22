using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class GenericUOWRepository<T> : IGenericUOWDal<T> where T : class
    {
        protected readonly Context _context;

        public GenericUOWRepository(Context context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void MultiUpdate(List<T> t)
        {
            _context.UpdateRange(t);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}
