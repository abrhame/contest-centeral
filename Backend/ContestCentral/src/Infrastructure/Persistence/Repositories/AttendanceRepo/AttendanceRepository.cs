using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContestCentral.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using ContestCentral.Domain.Entities;
using AutoMapper;
using ContestCentral.Infrastructure.Persistence;



namespace ContestCentral.src.Infrastructure.Persistence.Repositories.AttendanceRepo;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly ContestCentralDbContext _context;
    private readonly IMapper _mapper;


    public AttendanceRepository(ContestCentralDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Attendance> AddAttendance(Attendance entity)
    {
        var attendance = new Attendance
        {
            UserId = entity.UserId,
            ContestId = entity.ContestId,
            CreatedAt = entity.CreatedAt
        };

        var result = _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();

        return _mapper.Map<Attendance>(result);
    }

    public async Task<bool> contestExists(Guid contestId)
    {
        // return await _context.Contests.AnyAsync(c => c.Id == contestId);
        throw new Exception();
    }

    public async Task<List<Attendance>> GetContestsForUser(Guid userId)
    {
        var result = await _context.Attendances
            .Where(a => a.UserId == userId)
            .Select(a => a.ContestId)
            .ToListAsync();
        
        return _mapper.Map<List<Attendance>>(result);
    }

    public async Task<List<Attendance>> GetParticipantForContest(Guid contestId)
    {
        var result = await _context.Attendances
            .Where(a => a.ContestId == contestId)
            .Select(a => a.UserId)
            .ToListAsync();

        return _mapper.Map<List<Attendance>>(result);
    }

    public Task<bool> userExists(Guid userId)
    {
        // return await _context.users.AnyAsync(c => c.Id == contestId);
        throw new NotImplementedException();
    }
}