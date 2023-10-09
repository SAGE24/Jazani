using FluentValidation;

namespace Jazani.Application.Generals.Dtos.Measureunits.Validators;
public class MeasureunitValidator : AbstractValidator<MeasureunitSaveDto>
{
    public MeasureunitValidator() {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Symbol).NotNull().NotEmpty();
    }
}
