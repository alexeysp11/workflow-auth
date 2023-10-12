namespace WokflowLib.Authentication.Models.ConfigParameters;

/// <summary>
/// Checking user credentials config parameters.
/// </summary>
public class CheckUCConfig
{
    /// <summary>
    /// Shows if it is necessary to check the user login.
    /// </summary>
    public bool IsLoginRequired { get; set; }
    
    /// <summary>
    /// Shows if it is necessary to check the user email.
    /// </summary>
    public bool IsEmailRequired { get; set; }
    
    /// <summary>
    /// Shows if it is necessary to check the user phone number.
    /// </summary>
    public bool IsPhoneNumberRequired { get; set; }
    
    /// <summary>
    /// Shows if it is necessary to check the user password.
    /// </summary>
    public bool IsPasswordRequired { get; set; }
}