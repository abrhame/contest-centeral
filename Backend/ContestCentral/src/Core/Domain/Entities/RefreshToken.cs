namespace ContestCentral.Domain.Common.Entity;

public class RefreshToken : BaseEntity<Guid> {
    public Guid UserId { get; set; }
    public User user { get; set; } = null!;

    public string Token { get; set; } = string.Empty;

    public DateTime Expires { get; set; }
    public DateTime? Revoked { get; set; }

    public bool IsExpired => DateTime.UtcNow >= Expires;
    public bool IsRevoked => Revoked != null;
    public bool IsActive => Revoked == null && !IsExpired;
}
