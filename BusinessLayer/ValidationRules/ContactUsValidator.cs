using DTOLayer.DTOs.ContactUsDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactUsValidator : AbstractValidator<ContactUsDto>
    {
        public ContactUsValidator()
        {
            
        }
    }
}
