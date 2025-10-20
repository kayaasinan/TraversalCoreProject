using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public EfContactUsDal(Context context) : base(context)
        {
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            var values=_context.ContactUses.Where(x=>x.Status==false).ToList();
            return values;
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            var values = _context.ContactUses.Where(x => x.Status == true).ToList();
            return values;
        }

        public void ToggleMessageStatus(int id)
        {
            var values = _context.ContactUses.Find(id);
            if (values != null)
            {
                values.Status = !values.Status;
                Update(values);
            }
        }
    }
}
