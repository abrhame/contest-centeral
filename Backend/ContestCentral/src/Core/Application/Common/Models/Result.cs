namespace ContestCentral.Application.Common.Models;

public class Result {
    internal Result(bool success, string? message = null, IEnumerable<string>? errors = null) {
        Success = success;
        Message = message;
        Errors = errors;
    }

    public bool Success { get; init; }
    public string? Message { get; init; }
    public IEnumerable<string>? Errors { get; init; }

    public static Result SuccessResult(string message) {
        return new Result(true, message: message);
    }

    public static Result FailureResult(IEnumerable<string> errors) {
        return new Result(false, errors: errors);
    }
}
