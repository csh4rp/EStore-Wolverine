using EStore.Wolverine.Contracts.Commands.Shipments;
using FluentValidation;

namespace EStore.Wolverine.Application.Validators.Shipments;

internal sealed class CreateShipmentCommandValidator : AbstractValidator<CreateShipmentCommand>
{
    public CreateShipmentCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty();
    }
}
