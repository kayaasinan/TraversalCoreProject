using DTOLayer.DTOs.NewsletterDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class NewsletterValidator : AbstractValidator<NewsletterDto>
    {
        public NewsletterValidator()
        {
            
        }
    }
}
