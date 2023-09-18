using EStore.Wolverine.Contracts.Commands.Payments;
using FluentValidation;

namespace EStore.Wolverine.Application.Validators.Payments;

internal sealed class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty();
    }
}
