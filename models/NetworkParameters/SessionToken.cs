namespace WokflowLib.Authentication.Models.NetworkParameters;

public class SessionToken
{
    public string TokenGuid { get; set; }
    public System.DateTime TokenBeginDt { get; set; }
    public System.DateTime TokenEndDt { get; set; }
    public string VerificationCode { get; set; }
    public System.DateTime CodeSendingDt { get; set; }
    public string ExceptionMessage { get; set; }
}
