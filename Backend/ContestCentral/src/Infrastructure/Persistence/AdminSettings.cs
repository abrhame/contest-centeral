namespace Infrastructure.Persistence;

public class AdminSettings {
    public readonly string SectionName = "AdminSettings";
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
