using Cims.WorkflowLib.Models.ErrorHandling;

namespace WokflowLib.Authentication.Models.NetworkParameters;

public class SessionToken
{
    public string? TokenGuid { get; set; }
    public System.DateTime TokenBeginDt { get; set; }
    public System.DateTime TokenEndDt { get; set; }
    public string? ExceptionMessage { get; set; }
    public WorkflowException? WorkflowException { get; set; }
}
