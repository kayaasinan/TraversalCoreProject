using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AppUserValidator : AbstractValidator<AppUserDto>
    {
        public AppUserValidator()
        {
            
        }
    }
}
