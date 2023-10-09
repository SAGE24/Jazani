using FluentValidation;

namespace Jazani.Application.Mc.Dtos.Investments.Validators;
public class InvestmentValidator: AbstractValidator<InvestmentSaveDto>
{
    public InvestmentValidator() {
        RuleFor(v => v.Amountinvestd).NotNull().GreaterThan(0);
        RuleFor(v => v.Miningconcessionid).NotNull().GreaterThan(0).WithMessage("Favor de validar tabla relación");
        RuleFor(v => v.Investmenttypeid).NotNull().GreaterThan(0).WithMessage("Favor de validar tabla relación");
        RuleFor(v => v.Currencytypeid).NotNull().GreaterThan(0).WithMessage("Favor de validar tabla relación");
        RuleFor(v => v.Holderid).NotNull().GreaterThan(0).WithMessage("Favor de validar tabla relación");
        RuleFor(v => v.Declaredtypeid).NotNull().GreaterThan(0).WithMessage("Favor de validar tabla relación");
    }
}
