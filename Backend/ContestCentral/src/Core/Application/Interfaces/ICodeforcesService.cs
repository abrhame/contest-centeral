namespace Application.Interfaces;

public interface ICodeforcesService
{
    public Task<dynamic> GetContestData(string contestId);
}
