using DTOLayer.DTOs.CommentDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<CommentDto>
    {
        public CommentValidator()
        {
            
        }
    }
}
