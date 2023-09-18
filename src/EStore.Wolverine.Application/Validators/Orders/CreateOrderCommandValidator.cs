using EStore.Wolverine.Application.Validators.Common;
using EStore.Wolverine.Contracts.Commands.Orders;
using FluentValidation;

namespace EStore.Wolverine.Application.Validators.Orders;

internal sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Address)
            .NotNull()
            .SetValidator(new AddressValidator());;

        RuleFor(x => x.Lines)
            .NotEmpty();
        
        RuleForEach(x => x.Lines)
            .SetValidator(new OrderLineValidator());
    }
}
