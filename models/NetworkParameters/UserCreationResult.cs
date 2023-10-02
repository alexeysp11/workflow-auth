using Cims.WorkflowLib.Models.ErrorHandling;

namespace WokflowLib.Authentication.Models.NetworkParameters;

public class UserCreationResult
{
    public bool IsUserAdded { get; set; }
    public string? SignUpGuid { get; set; }
    public string? VerificationCode { get; set; }
    public System.DateTime CodeSendingDt { get; set; }
    public UserExistance? UserExistanceBefore { get; set; }
    public UserExistance? UserExistanceAfter { get; set; }
    public string? ExceptionMessage { get; set; }
    public WorkflowException? WorkflowException { get; set; }
}
