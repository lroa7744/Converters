using Converters.Domain.Abstractions.Models.Database;

namespace Converters.Domain.Models.Database;

public class URL : IDatabaseObject
{
    public int Id { get; set; }
    public string? Value { get; set; }
}
