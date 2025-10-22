using DTOLayer.DTOs.AboutDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<AboutDto>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz....!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen görsel seçiniz....!");
            RuleFor(x => x.Description).MinimumLength(30).WithMessage("Lütfen en az 50 karekterlik açıklama bilgisi giriniz....!");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Lütfen açıklama bilgisi kısaltınız....!");
        }
    }
}
