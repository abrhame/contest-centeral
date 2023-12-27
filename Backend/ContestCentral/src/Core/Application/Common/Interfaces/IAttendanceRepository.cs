using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContestCentral.Domain.Entities;

namespace ContestCentral.Application.Common.Interfaces; 

public interface IAttendanceRepository
{
    Task<Attendance> AddAttendance(Attendance entity);
    Task<List<Attendance>> GetParticipantForContest(Guid contestId);
    Task<List<Attendance>> GetContestsForUser(Guid userId);
    Task<bool> userExists(Guid userId);
    Task<bool> contestExists(Guid contestId);
}
