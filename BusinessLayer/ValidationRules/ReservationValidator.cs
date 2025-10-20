using DTOLayer.DTOs.ReservationDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ReservationValidator : AbstractValidator<ReservationDto>
    {
        public ReservationValidator()
        {
            
        }
    }
}
