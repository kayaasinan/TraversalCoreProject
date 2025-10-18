using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz...!")
                                .MaximumLength(30).WithMessage("Lütfen en fazla 30 karekterlik isim giriniz...!");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Bu alan boş bırakılamaz...!")
                                      .MinimumLength(3).WithMessage("Lütfen en az 3 karekterlik açıklama giriniz...!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Bu alan boş bırakılamaz...!");
            RuleFor(x => x.XUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz...!");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz...!");


        }
    }
}
