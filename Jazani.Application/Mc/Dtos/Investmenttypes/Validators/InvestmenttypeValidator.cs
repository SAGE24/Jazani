using FluentValidation;

namespace Jazani.Application.Mc.Dtos.Investmenttypes.Validators;
public class InvestmenttypeValidator : AbstractValidator<InvestmenttypeSaveDto>
{
    public InvestmenttypeValidator() {
        RuleFor(x => x.Name).NotNull().NotEmpty();
    }
}
