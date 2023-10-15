namespace WokflowLib.Authentication.Models.ConfigParameters;

/// <summary>
/// 
/// </summary>
public class AuthResolverSettings
{
    /// <summary>
    /// Checking user credentials config parameters.
    /// </summary>
    public CheckUCConfig CheckUCConfig { get; set; }

    /// <summary>
    /// Settings for DB.
    /// </summary>
    public DBSettings DBSettings { get; set; }

    /// <summary>
    /// Settings for network communication.
    /// </summary>
    public NetworkSettings NetworkSettings { get; set; }
}