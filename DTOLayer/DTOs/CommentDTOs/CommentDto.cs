using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.DestinationDTOs;

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
        public string? AppUserImageUrl { get; set; }
    }
}
