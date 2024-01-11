using Domain.Common;
using Domain.Constant;

namespace Domain.Entity;

public class Verification : BaseEntity<Guid> 
{
    public string Token { get; set; } = string.Empty;
    public DateTime? ExpirationDate { get; set; }

    public VerificationType VerificationType { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}
