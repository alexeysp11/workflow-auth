namespace WokflowLib.Authentication.Models.NetworkParameters;

public class VerifySignUpResponse
{
    public bool IsSuccessful { get; set; }
    public string? ExceptionMessage { get; set; }
}
