using Domain.Common;

namespace Domain.Entity;

public class Submission : BaseEntity<Guid>
{
    public string QuestionId { get; set; } = default!;
    public Question Question { get; set; } = null!;

    public int Trial { get; set; }
    public int Points { get; set; }

    public Guid? TeamId { get; set; }
    public Team? Team { get; set; }

    public Guid? UserId { get; set; }
    public User? User { get; set; }

    public Guid ContestId { get; set; }
    public Contest Contest { get; set; } = null!;
}
