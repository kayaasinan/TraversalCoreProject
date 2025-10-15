using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Destination { get; set; } 
        public int NumberOfPeople { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Notes { get; set; }
        public ReservationStatus Status { get; set; }
    }
    public enum ReservationStatus
    {
        OnayBekliyor = 0,
        Onaylandi = 1,
        IptalEdildi = 2,
        DevamEdiyor = 3,
        Tamamlandi = 4
    }
}
