using Domain.Common;

namespace Domain.Entity;

public class Team : BaseEntity<Guid> 
{
    public string Name { get; set; } = string.Empty;

    public ICollection<User> Users { get; set; } = new List<User>();

    public ICollection<Contest> Contests { get; set; } = new List<Contest>();

    public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}

