using FluentValidation;

namespace Jazani.Application.Mc.Dtos.Miningconcessions.Validators;
public class MiningconcessionValidator : AbstractValidator<MiningconcessionSaveDto>
{
    public MiningconcessionValidator() { 
        RuleFor(x => x.Name).NotNull().NotEmpty();
    }
}
