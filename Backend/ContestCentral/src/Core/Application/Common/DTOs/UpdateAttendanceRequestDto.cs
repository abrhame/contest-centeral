namespace ContestCentral.Application.Common.DTOs;

public class UpdateAttendanceRequestDto
{
    public Guid userId{get; set;}
    public Guid contestId{get; set;}
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}