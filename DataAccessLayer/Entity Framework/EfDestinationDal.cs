using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entity_Framework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public EfDestinationDal(Context context) : base(context)
        {
        }

        public Destination? GetDestinationWithGuide(int id)
        {
            var values = _context.Destinations.Where(x => x.DestinationId == id).Include(x => x.Guide).FirstOrDefault();
            return values == null ? null : values;
        }
    }
}
