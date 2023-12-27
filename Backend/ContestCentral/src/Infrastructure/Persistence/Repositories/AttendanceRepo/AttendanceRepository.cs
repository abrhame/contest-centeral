using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContestCentral.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using ContestCentral.Domain.Entities;
using AutoMapper;



namespace ContestCentral.src.Infrastructure.Persistence.Repositories.AttendanceRepo;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly ApiDbContext _context;
    private readonly IMapper _mapper;
    public Task<Attendance> AddAttendance(Attendance entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> contestExists(Guid contestId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Attendance>> GetContestsForUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Attendance>> GetParticipantForContest(Guid contestId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> userExists(Guid userId)
    {
        throw new NotImplementedException();
    }
}