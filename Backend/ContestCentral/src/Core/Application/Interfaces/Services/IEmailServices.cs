using Application.Common.Models;
using Application.DTOs;

namespace Application.Interfaces;

public interface IEmailServices
{
    Task<Result> SendAsync(EmailMetadata request);
}
