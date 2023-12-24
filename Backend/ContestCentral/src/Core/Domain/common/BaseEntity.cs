using System.ComponentModel.DataAnnotations.Schema;

namespace ContestCentral.Domain.Common;

public abstract class BaseEntity<T> {
    public T Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    private readonly List<BaseEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent) {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent) {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents() {
        _domainEvents.Clear();
    }
}
