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
        public string? DestinationCity { get; set; }
    }
}
