using Cims.WorkflowLib.Models.ErrorHandling;

namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// Verify user credentials response 
/// </summary>
public class VUCResponse
{
    public bool IsVerified { get; set; }
    public string? UserUid { get; set; }
    public UserCredentials? UserCredentials { get; set; }
    public string? ExceptionMessage { get; set; }
    public WorkflowException? WorkflowException { get; set; }
}
