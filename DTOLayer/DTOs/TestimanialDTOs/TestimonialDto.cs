using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.TestimanialDTOs
{
    public class TestimonialDto
    {
        public int? TestimonialId { get; set; }
        public string? Client { get; set; }
        public string? Comment { get; set; }
        public string? ClientImage { get; set; }
        public bool Status { get; set; }
    }
}
