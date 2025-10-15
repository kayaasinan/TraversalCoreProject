using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{

    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(Context context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public List<T> GetList()
        {
            return _table.ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _table.Where(filter).ToList();
        }

        public void Insert(T t)
        {
            _table.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _table.Update(t);
            _context.SaveChanges();
        }
    }
}
