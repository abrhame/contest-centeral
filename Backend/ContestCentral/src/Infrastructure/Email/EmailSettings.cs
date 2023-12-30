namespace ContestCentral.Infrastructure.Email;

public class EmailSettings {
    public readonly string SectionName = "EmailSettings";
    public string DefaultFromEmail { get; set; } = String.Empty;
    public string Host { get; set; } = String.Empty;
    public int Port { get; set; }
    public string UserName { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}
