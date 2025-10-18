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
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public EfReservationDal(Context context) : base(context)
        {
        }

        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            return _context.Reservations.Include(x => x.Destination).Include(x=>x.AppUser).Where(x => x.Status == ReservationStatus.Onaylandi && x.AppUserId == id).ToList();
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            return _context.Reservations.Include(x => x.Destination).Where(x => x.Status == ReservationStatus.GeçmiþRezervasyon && x.AppUserId == id).ToList();
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            return _context.Reservations.Include(x=>x.Destination).Where(x=>x.Status==ReservationStatus.OnayBekliyor && x.AppUserId==id).ToList();  
        }
    }
}
