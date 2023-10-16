using System.Data;
using Cims.WorkflowLib.DbConnections;
using Cims.WorkflowLib.Models.ErrorHandling;
using WokflowLib.Authentication.Models.ConfigParameters;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

/// <summary>
/// Class that processes authentication requests and interacts with the DB directly.
/// </summary>
public class AuthResolverDB : AuthResolver, IAuthResolver
{
    /// <summary>
    /// 
    /// </summary>
    private PgDbConnection PgDbConnection { get; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public AuthResolverDB()
    {
        AuthResolverSettings = new AuthResolverSettings
        {
            CheckUCConfig = ConfigHelper.GetUCConfigs(),
            AuthDBSettings = ConfigHelper.GetAuthDBSettings()
        };
        PgDbConnection = new PgDbConnection(AuthResolverSettings.AuthDBSettings.ConnectionString);
    }

    /// <summary>
    /// Method that creates the specified user.
    /// </summary>
    public UserCreationResult AddUser(UserCredentials request)
    {
        var response = new UserCreationResult();
        try
        {
            if (AuthResolverSettings.CheckUCConfig.IsLoginRequired && string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (AuthResolverSettings.CheckUCConfig.IsEmailRequired && string.IsNullOrWhiteSpace(request.Email))
                throw new System.Exception("Parameter 'Email' could not be null or empty");
            if (AuthResolverSettings.CheckUCConfig.IsPhoneNumberRequired && string.IsNullOrWhiteSpace(request.PhoneNumber))
                throw new System.Exception("Parameter 'PhoneNumber' could not be null or empty");
            if (AuthResolverSettings.CheckUCConfig.IsPasswordRequired && string.IsNullOrWhiteSpace(request.Password))
                throw new System.Exception("Parameter 'Password' could not be null or empty");
            if (string.IsNullOrWhiteSpace(AuthResolverSettings.AuthDBSettings.AddUserSQL))
                throw new System.Exception("SQL statement could not be null or empty");
            // 
            string sqlRequest = string.Format(AuthResolverSettings.AuthDBSettings.AddUserSQL, 
                request.Login, request.Email, request.PhoneNumber, request.Password);
            PgDbConnection.ExecuteSqlCommand(sqlRequest);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex);
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
        return response;
    }
    
    /// <summary>
    /// Method for user verification.
    /// </summary>
    public VUCResponse VerifyUserCredentials(UserCredentials request)
    {
        var response = new VUCResponse();
        try
        {
            if (AuthResolverSettings.CheckUCConfig.IsLoginRequired && string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (AuthResolverSettings.CheckUCConfig.IsPasswordRequired && string.IsNullOrWhiteSpace(request.Password))
                throw new System.Exception("Parameter 'Password' could not be null or empty");
            if (string.IsNullOrWhiteSpace(AuthResolverSettings.AuthDBSettings.VerifyUserCredentialsSQL))
                throw new System.Exception("SQL statement could not be null or empty");
            // 
            string sqlRequest = string.Format(AuthResolverSettings.AuthDBSettings.VerifyUserCredentialsSQL, 
                request.Login, request.Password);
            var dataTable = PgDbConnection.ExecuteSqlCommand(sqlRequest);
        }
        catch (System.Exception ex)
        {
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
        return response;
    }
}