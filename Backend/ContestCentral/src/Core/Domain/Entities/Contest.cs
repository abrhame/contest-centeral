using Domain.Common;
using Domain.Constant;

namespace Domain.Entity;

public class Contest: BaseEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public ContestType ContestType { get; set; } = ContestType.Individual;
    public ContestStatus ContestStatus { get; set; } = ContestStatus.Upcoming; 
    public string? ContestUrl { get; set; }
    public DateTime ContestDate { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
    public ICollection<Question> Questions { get; set; } = new List<Question>();

    public ICollection<User>? Users { get; set; }
    public ICollection<Team>? Teams { get; set; }

    public ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public bool IsIndividual => ContestType == ContestType.Individual;
}
