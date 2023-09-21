using WokflowLib.Authentication.Models.ConfigParameters;

namespace WokflowLib.Authentication.AuthBL;

public static class ConfigHelper
{
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