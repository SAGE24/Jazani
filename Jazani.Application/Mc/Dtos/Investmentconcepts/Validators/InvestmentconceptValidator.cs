using FluentValidation;

namespace Jazani.Application.Mc.Dtos.Investmentconcepts.Validators;
public class InvestmentconceptValidator : AbstractValidator<InvestmentconceptSaveDto>
{
    public InvestmentconceptValidator() { 
        RuleFor(x => x.Name).NotNull().NotEmpty();
    }
}
