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

    public static AuthDBSettings GetAuthDBSettings()
    {
        return new AuthDBSettings
        {
            DBProvider = "postgres",
            ConnectionString = "Server=127.0.0.1;Port=5432;Userid=postgres;Password=postgres;Database=postgres",
            AddUserSQL = @"insert into users (login, email, phone_number, password) values ({0}, {1}, {2}, {3});",
            VerifyUserCredentialsSQL = @"select u.uid qty from users u where u.login = {0} and u.password = {2};"
        };
    }
}