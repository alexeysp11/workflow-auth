namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// Virify sign up response
/// </summary>
public class VSUResponse
{
    public bool IsSuccessful { get; set; }
    public string? ExceptionMessage { get; set; }
}
