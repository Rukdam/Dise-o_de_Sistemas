namespace WebApiCSharp.Domain.ValueObjects;

public class PermissionResult
{
    public bool Granted { get; }
    public string Reason { get; }

    public PermissionResult(bool granted, string reason)
    {
        Granted = granted;
        Reason = reason;
    }

    public bool IsGranted() => Granted;
}
