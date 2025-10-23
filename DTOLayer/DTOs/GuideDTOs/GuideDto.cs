using DTOLayer.DTOs.DestinationDTOs;

namespace DTOLayer.DTOs.GuideDTOs
{
    public class GuideDto
    {
        public int? GuideId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? XUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? Description2 { get; set; }
        public bool Status { get; set; }
        public List<DestinationDto> Destinations { get; set; }
    }
}
