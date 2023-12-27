using ContestCentral.Domain.Common;


namespace ContestCentral.Domain.Entities;

public class Attendance:BaseEntity<Guid>
{
    public Guid UserId{get; set;}
    public Guid ContestId{get; set;}    
}