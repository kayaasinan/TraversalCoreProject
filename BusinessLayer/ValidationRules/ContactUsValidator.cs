using DTOLayer.DTOs.ContactUsDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactUsValidator : AbstractValidator<ContactUsDto>
    {
        public ContactUsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş bırakılamaz")
                                    .MinimumLength(5).WithMessage("En az 5 karakter veri girişi yapmalısınız..!")
                                    .MaximumLength(100).WithMessage("En fazla 100 karakter veri girişi yapmalısınız");
            RuleFor(x => x.Body).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş bırakılamaz")
                                .MinimumLength(5).WithMessage("En az 5 karakter veri girişi yapmalısınız..!")
                                .MaximumLength(100).WithMessage("En fazla 100 karakter veri girişi yapmalısınız");

        }
    }
}
