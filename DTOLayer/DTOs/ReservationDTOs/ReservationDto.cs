using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.DestinationDTOs;

namespace DTOLayer.DTOs.ReservationDTOs
{
    public class ReservationDto
    {
        public int? ReservationId { get; set; }
        public int DestinationId { get; set; }
        public DestinationDto Destination { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
        public int AppUserId { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}
