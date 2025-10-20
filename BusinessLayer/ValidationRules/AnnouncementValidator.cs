using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementDto>
    {
        public AnnouncementValidator()
        {
            
        }
    }
}
