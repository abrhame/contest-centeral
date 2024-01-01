using Domain.Common;

namespace Domain.Entity;

public class Location : BaseEntity<Guid>
{
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;

    public string ShortName { get; set; } = string.Empty;

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}
