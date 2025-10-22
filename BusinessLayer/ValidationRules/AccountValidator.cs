using DTOLayer.DTOs.AccountDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AccountValidator : AbstractValidator<AccountDto>
    {
        public AccountValidator()
        {
            
        }
    }
}
