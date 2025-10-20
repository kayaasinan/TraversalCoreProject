using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ReservationDTOs
{
    public class ReservationDto
    {
        public int? ReservationId { get; set; }
        public int AppUserId { get; set; }
        public int DestinationId { get; set; }
        public string? DestinationCity { get; set; }
        public string? AppUserName { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
    }
}
