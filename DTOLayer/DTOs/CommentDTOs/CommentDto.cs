using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.DestinationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CommentDTOs
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string? CommentUser { get; set; }
        public DateTime CommentDate { get; set; }
        public string? CommentContent { get; set; }
        public bool CommentState { get; set; }
        public int DestinationId { get; set; }
        public DestinationDto Destination { get; set; }
        public int AppUserId { get; set; }
        public AppUserDto AppUser { get; set; }
        public string? AppUserFullName { get; set; }
        public string? AppUserImageUrl { get; set; }
    }
}
