using DTOLayer.DTOs.ReservationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserDto
    {
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Gender { get; set; }
        public List<ReservationDto> Reservations { get; set; } = new();
    }
}
