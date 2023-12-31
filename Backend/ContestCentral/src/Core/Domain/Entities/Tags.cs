using Domain.Common;

namespace Domain.Entity;

public class Tags : BaseEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;

    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
