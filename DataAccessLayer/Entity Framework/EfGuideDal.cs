using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public EfGuideDal(Context context) : base(context)
        {
        }

        public void ChangeGuideStatus(int id)
        {
            var values = _context.Guides.Find(id);
            if (values != null)
            {
                values.Status = !values.Status;
                Update(values);
            }
        }
    }
}
