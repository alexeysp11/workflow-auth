namespace WokflowLib.Authentication.Models.ConfigParameters;

/// <summary>
/// Settings for DB.
/// </summary>
public class DBSettings
{
    /// <summary>
    /// Name of the DB provider.
    /// </summary>
    public string DBProvider { get; set; }
    
    /// <summary>
    /// Connection string.
    /// </summary>
    public string ConnectionString { get; set; }
}