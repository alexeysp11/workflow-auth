namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// Verify sign up request 
/// </summary>
public class VSURequest
{
    public string? SignUpGuid { get; set; }
    public int TriesNumber { get; set; }
    public bool IsDeprecated { get; set; }
    public bool IsOverriden { get; set; }
    public string? SignUpClosingCode { get; set; }
}
