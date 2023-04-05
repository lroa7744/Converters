using Converters.Domain.Abstractions.Models.Database;

namespace Converters.Domain.Models.Database;

public partial class URL : IDatabaseObject
{
    public int Id { get; set; }
    public string? Value { get; set; }
}
