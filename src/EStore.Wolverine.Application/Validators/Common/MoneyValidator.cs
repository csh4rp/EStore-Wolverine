using EStore.Wolverine.Contracts.Models.Common;
using FluentValidation;

namespace EStore.Wolverine.Application.Validators.Common;

internal sealed class MoneyValidator : AbstractValidator<MoneyModel>
{
    public MoneyValidator()
    {
        RuleFor(x => x.Value)
            .GreaterThan(0);

        RuleFor(x => x.Currency)
            .NotEmpty();
    }
}
