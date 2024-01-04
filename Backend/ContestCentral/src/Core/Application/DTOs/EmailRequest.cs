namespace Application.DTOs;

public record EmailRequest(string[] Emails, string Subject, string Message);
