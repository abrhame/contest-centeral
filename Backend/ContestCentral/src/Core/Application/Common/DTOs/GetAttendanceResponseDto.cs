namespace ContestCentral.Application.Common.DTOs;

public class GetAttendanceResponseDto
{
    public Guid userId{get; set;}
    public Guid contestId{get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}