using System.Text.Json.Serialization;
using EStore.Wolverine.Domain.Enums;

namespace EStore.Wolverine.Contracts.Models.Common;

public record MoneyModel
{
    public required decimal Value { get; init; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required Currency Currency { get; init; }
}
