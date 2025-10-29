using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.Entity_Framework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonialDal(Context context) : base(context)
        {
        }

        public void ChangeGuideStatus(int id)
        {
            var values = _context.Testimonials.Find(id);
            if (values != null)
            {
                values.Status = !values.Status;
                Update(values);
            }
        }
    }
}
