using FluentValidation;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Validators;
public class MineralTypeValidator : AbstractValidator<MineralTypeSaveDto>
{
    public MineralTypeValidator() {
        RuleFor(v => v.Name).NotEmpty().NotNull();
    }
}
