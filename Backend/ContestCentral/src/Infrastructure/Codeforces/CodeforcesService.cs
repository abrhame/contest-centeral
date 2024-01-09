using Application.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json; 
using System.Text;
using System.Security.Cryptography;

namespace Infrastructure.Codeforces;

public class CodeforcesService : ICodeforcesService
{
    private readonly CodeforcesSettings _codeforcesSettings;
    private readonly HttpClient _httpClient;

    public CodeforcesService(IOptions<CodeforcesSettings> codeforcesSettings, HttpClient httpClient)
    {
        _codeforcesSettings = codeforcesSettings.Value;
        _httpClient = httpClient;
    }

    public async Task<dynamic> GetContestData(string contestId)
    {
        string randStr = GenerateRandomString();
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        string apiSig = $"{randStr}/contest.standings?apiKey={_codeforcesSettings.ApiKey}&contestId={contestId}&time={currentTime}#{_codeforcesSettings.ApiSecret}";
        string hash = CalculateSHA512(apiSig);

        string url = $"https://codeforces.com/api/contest.standings?contestId={contestId}&apiKey={_codeforcesSettings.ApiKey}&time={currentTime}&apiSig={randStr}{hash}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        string responseData = await response.Content.ReadAsStringAsync();

        dynamic data = JsonConvert.DeserializeObject(responseData)!;
        return data; 
    }

    private static string GenerateRandomString()
    {
        Random random = new Random();
        int rand = random.Next(100000);
        return rand.ToString("D6");
    }

    public static string CalculateSHA512(string input)
    {
        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hashBytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }

}
