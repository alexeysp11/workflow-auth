namespace WokflowLib.Authentication.Models.ConfigParameters;

/// <summary>
/// Checking user credentials config parameters
/// </summary>
public class CheckUCConfig
{
    public bool IsLoginRequired { get; set; }
    public bool IsEmailRequired { get; set; }
    public bool IsPhoneNumberRequired { get; set; }
    public bool IsPasswordRequired { get; set; }
}