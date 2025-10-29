using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

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

        public List<Guide> GetLast7Guide()
        {
           return _context.Guides.OrderByDescending(x=>x.GuideId).Take(7).ToList();
        }
    }
}
