namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Notes { get; set; }
        public ReservationStatus Status { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
    public enum ReservationStatus
    {
        OnayBekliyor = 0,
        Onaylandi = 1,
        GeçmiþRezervasyon = 2,
        IptalEdildi = 3,
        Tamamlandi = 4
    }
}
