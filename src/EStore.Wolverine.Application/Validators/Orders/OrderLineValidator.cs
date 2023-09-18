using EStore.Wolverine.Application.Validators.Common;
using EStore.Wolverine.Contracts.Models.Orders;
using FluentValidation;

namespace EStore.Wolverine.Application.Validators.Orders;

internal sealed class OrderLineValidator : AbstractValidator<OrderLineModel>
{
    public OrderLineValidator()
    {
        RuleFor(x => x.UnitPrice)
            .SetValidator(new MoneyValidator());

        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .GreaterThan(0);
    }
}
