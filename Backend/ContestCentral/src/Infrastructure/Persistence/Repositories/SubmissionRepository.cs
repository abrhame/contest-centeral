using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly ContestCentralDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubmissionRepository(ContestCentralDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SubmissionDTO>> GetAllSubmissionsAsync()
        {
            var submissions = await _dbContext.TeamSubmissions.ToListAsync();
            return _mapper.Map<IEnumerable<SubmissionDTO>>(submissions);
        }

        public async Task<SubmissionDTO> GetSubmissionByIdAsync(Guid submissionId)
        {
            var submission = await _dbContext.TeamSubmissions.SingleOrDefaultAsync(s => s.Id == submissionId);
            return _mapper.Map<SubmissionDTO>(submission);
        }

        public async Task<IEnumerable<SubmissionDTO>> GetSubmissionsByUserIdAsync(Guid userId)
        {
            var submissions = await _dbContext.TeamSubmissions.Where(s => s.UserId == userId).ToListAsync();
            return _mapper.Map<IEnumerable<SubmissionDTO>>(submissions);
        }

        public async Task<IEnumerable<SubmissionDTO>> GetSubmissionsByQuestionIdAsync(string questionId)
        {
            var submissions = await _dbContext.TeamSubmissions.Where(s => s.QuestionId == questionId).ToListAsync();
            return _mapper.Map<IEnumerable<SubmissionDTO>>(submissions);
        }

        public async Task<IEnumerable<SubmissionDTO>> GetSubmissionsByContestIdAsync(Guid contestId)
        {
            var submissions = await _dbContext.TeamSubmissions.Where(s => s.ContestId == contestId).ToListAsync();
            return _mapper.Map<IEnumerable<SubmissionDTO>>(submissions);
        }

        public async Task AddSubmissionAsync(SubmissionDTO submission)
        {
            var entity = _mapper.Map<Submission>(submission);
            _dbContext.TeamSubmissions.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateSubmissionAsync(SubmissionDTO submission)
        {
            var existingSubmission = await _dbContext.TeamSubmissions.SingleOrDefaultAsync(s => s.Id == submission.Id);

            if (existingSubmission != null)
            {
                _mapper.Map(submission, existingSubmission);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
