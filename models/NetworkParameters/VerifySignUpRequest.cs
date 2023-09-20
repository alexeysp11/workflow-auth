namespace WokflowLib.Authentication.Models.NetworkParameters;

public class VerifySignUpRequest
{
    public string? UserGuid { get; set; }
    public int TriesNumber { get; set; }
    public bool IsDeprecated { get; set; }
    public bool IsOverriden { get; set; }
    public string? SignUpClosingCode { get; set; }
}
