using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entity_Framework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public EfReservationDal(Context context) : base(context)
        {
        }

        public void ChangeReservationStatus(int id, ReservationStatus newStatus)
        {
            var reservation = _context.Reservations.FirstOrDefault(x => x.ReservationId == id);
            if (reservation != null)
            {
                reservation.Status = newStatus;
                _context.SaveChanges();
            }
        }

        public List<Reservation> GetAllReservationsWithDetails()
        {
            return _context.Reservations.Include(x => x.Destination).Include(x => x.AppUser).ToList();
        }

        public List<Reservation> GetCanceledReservationsByAdmin(int id)
        {
            return _context.Reservations.Include(x => x.Destination).Include(x => x.AppUser).Where(x => x.Status == ReservationStatus.IptalEdildi && x.AppUserId == id).ToList();
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
