using Domain.Constant;

namespace Application.DTOs;

public record ContestDto
{
    public string Name { get; set; } = null!;
    public ContestType ContestType { get; set; }
    public ContestStatus ContestStatus { get; set; }
    public string ContestUrl { get; set; } = null!;
    public DateTime ContestDate { get; set; }
    public string CreatorName { get; set; } = null!;
    public int Duration { get; set; }
};