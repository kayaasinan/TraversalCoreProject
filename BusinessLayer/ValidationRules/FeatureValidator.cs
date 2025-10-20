using DTOLayer.DTOs.FeatureDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class FeatureValidator : AbstractValidator<FeatureDto>
    {
        public FeatureValidator()
        {
            
        }
    }
}
