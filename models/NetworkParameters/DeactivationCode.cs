namespace WokflowLib.Authentication.Models.NetworkParameters;

public class DeactivationCode
{
    public string? DeactivationGuid { get; set; }
    public string? Code { get; set; }
    public System.DateTime CodeSendingDt { get; set; }
    public string? ExceptionMessage { get; set; }
}