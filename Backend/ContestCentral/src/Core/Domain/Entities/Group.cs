using Domain.Common;

namespace Domain.Entity;

public class Group : BaseEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;

    public ICollection<User> Users { get; set; } = new List<User>();

    public ICollection<Contest> Contests { get; set; } = new List<Contest>(); 

    public Guid LocationId { get; set; }
    public Location Location { get; set; } = null!;

    public ICollection<Question> Questions { get; set; } = new List<Question>();
}

