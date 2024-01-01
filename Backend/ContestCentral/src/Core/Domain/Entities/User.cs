using Domain.Common;
using Domain.Constant;

namespace Domain.Entity;

public class User : BaseEntity<Guid> 
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public DateTime? EmailVerified { get; set; }
    public string PasswordHashed { get; set; } = string.Empty;

    public string? Avatar { get; set; }
    public string? Bio { get; set; }

    public Role Role { get; set; } = Role.Student;

    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;

    public ICollection<Team> Teams { get; set; } = new List<Team>();
    public ICollection<Contest> Contests { get; set; } = new List<Contest>();
    public ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public Guid? VerificationId { get; set; }
    public Verification? Verification { get; set; }
}
