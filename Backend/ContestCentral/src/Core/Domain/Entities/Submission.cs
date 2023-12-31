using Domain.Common;

namespace Domain.Entity;

public class Submission : BaseEntity<Guid>
{
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    public int Attempts { get; set; }

    public Guid? TeamId { get; set; }
    public Team? Team { get; set; }

    public Guid? UserId { get; set; }
    public User? User { get; set; }

    public Guid ContestId { get; set; }
    public Contest Contest { get; set; } = null!;
}
