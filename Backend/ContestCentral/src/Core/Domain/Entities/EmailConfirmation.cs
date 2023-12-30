namespace ContestCentral.Domain.Common.Entity;

public class EmailConfirmation : BaseEntity<Guid> {
    public required Guid UserId { get; set; }
    public required string Code { get; set; }
    public DateTime Expires { get; set; } = DateTime.UtcNow.AddHours(6);
}
