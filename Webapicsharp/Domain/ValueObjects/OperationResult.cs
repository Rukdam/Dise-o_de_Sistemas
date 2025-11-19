namespace WebApiCSharp.Domain.ValueObjects;

public class OperationResult
{
    public bool Success { get; }
    public string? Message { get; }

    public OperationResult(bool success, string? message = null)
    {
        Success = success;
        Message = message;
    }

    public static OperationResult Ok(string? msg = null)
        => new(true, msg);

    public static OperationResult Fail(string msg)
        => new(false, msg);

    public bool IsSuccess() => Success;
}
