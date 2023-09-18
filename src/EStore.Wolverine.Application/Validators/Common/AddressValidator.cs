using EStore.Wolverine.Contracts.Models.Common;
using FluentValidation;

namespace EStore.Wolverine.Application.Validators.Common;

internal sealed class AddressValidator : AbstractValidator<AddressModel>
{
    public AddressValidator()
    {
        RuleFor(x => x.FirstLine)
            .NotEmpty();

        RuleFor(x => x.SecondLine)
            .NotEmpty();
    }
}
