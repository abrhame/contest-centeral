namespace Application.Interfaces;

public interface ICodeforcesService
{
    public Task<dynamic> GetContestData(string contestId);
    public Task<bool> CheckUrl(string url);
}
