namespace WokflowLib.Authentication.Models;

/// <summary>
/// 
/// </summary>
public class AuthClosingCode
{
    /// <summary>
    /// 
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Uid { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public AuthClosingCodeType Type { get; set; }
}