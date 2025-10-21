using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş bırakılamaz")
                                 .MinimumLength(5).WithMessage("Lütfen en az 5 karekter veri girişi yapınız")
                                 .MaximumLength(50).WithMessage("Lütfen en fazla 50 karekter veri girişi yapınız");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Bu alan boş bırakılamaz")
                                   .MinimumLength(50).WithMessage("Lütfen en az 5 karekter veri girişi yapınız")
                                   .MaximumLength(500).WithMessage("Lütfen en fazla 50 karekter veri girişi yapınız");

        }
    }
}
