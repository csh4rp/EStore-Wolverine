using EStore.Wolverine.Application.Validators.Common;
using EStore.Wolverine.Contracts.Commands.Products;
using FluentValidation;

namespace EStore.Wolverine.Application.Validators.Products;

internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Ean)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(128);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(2000);

        RuleFor(x => x.UnitPrice)
            .NotNull()
            .SetValidator(new MoneyValidator());
    }
}
