using EStore.Wolverine.Domain.Enums;

namespace EStore.Wolverine.Domain.ValueObjects;

public record Money(decimal Value, Currency Currency);
