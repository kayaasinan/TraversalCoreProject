using DTOLayer.DTOs.CommentDTOs;
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
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Gender { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<ReservationDto> Reservations { get; set; } = new();
        public List<CommentDto> Comments { get; set; } = new();

    }
}
