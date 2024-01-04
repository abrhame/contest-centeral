using Domain.Common;

namespace Domain.Entity; 

public class Token : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string RefreshToken { get; set; } = string.Empty;
    public DateTime Expires { get; set; } = DateTime.UtcNow.AddDays(7);
}
