using Application.Common.Models;
using Application.DTOs;

namespace Application.Interfaces;

public interface IEmailService
{
    Task<Result> SendAsync(EmailMetadata request);
}
