using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<IEnumerable<SubmissionDTO>> GetAllSubmissionsAsync();
        Task<SubmissionDTO> GetSubmissionByIdAsync(Guid submissionId);
        Task<IEnumerable<SubmissionDTO>> GetSubmissionsByUserIdAsync(Guid userId);
        Task<IEnumerable<SubmissionDTO>> GetSubmissionsByQuestionIdAsync(string questionId);
        Task<IEnumerable<SubmissionDTO>> GetSubmissionsByContestIdAsync(Guid contestId);
        Task AddSubmissionAsync(SubmissionDTO submission);
        Task UpdateSubmissionAsync(SubmissionDTO submission);
    }
}
