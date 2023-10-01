using WokflowLib.Authentication.Models.ConfigParameters;

namespace WokflowLib.Authentication.AuthBL;

public static class ConfigHelper
{
    /// <summary>
    /// Check user credentials config file 
    /// </summary>
    public static CheckUCConfig GetUCConfigs()
    {
        return new CheckUCConfig()
        {
            IsLoginRequired = true,
            IsEmailRequired = false,
            IsPhoneNumberRequired = false,
            IsPasswordRequired = true
        };
    }
}