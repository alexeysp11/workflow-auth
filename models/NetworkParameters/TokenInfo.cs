namespace WokflowLib.Authentication.Models.NetworkParameters;

public class TokenInfo
{
    public string TokenGuid { get; set; }
    public bool TriesNumber { get; set; }
    public bool IsDeprecated { get; set; }
    public bool IsOverriden { get; set; }
    public string SignUpClosingCode { get; set; }
}
