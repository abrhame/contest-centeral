using Domain.Common;

namespace Domain.Entity;

public class Question : BaseEntity<string> 
{
    public int AskedCount { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Rating { get; set; }

    public ICollection<Tags> Tags { get; set; } = new List<Tags>();
    public ICollection<Contest> Contests { get; set; } = new List<Contest>();
    public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
    public ICollection<Group> Groups{get; set;} 
}
