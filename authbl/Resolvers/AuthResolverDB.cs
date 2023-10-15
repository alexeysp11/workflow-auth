using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

/// <summary>
/// Class that processes authentication requests and interacts with the DB directly.
/// </summary>
public class AuthResolverDB : AuthResolver, IAuthResolver
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public AuthResolverDB()
    {
        CheckUCConfig = ConfigHelper.GetUCConfigs();
    }

    /// <summary>
    /// Method that creates the specified user.
    /// </summary>
    public UserCreationResult AddUser(UserCredentials request)
    {
        var response = new UserCreationResult();
        try
        {
            if (CheckUCConfig.IsLoginRequired && string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (CheckUCConfig.IsEmailRequired && string.IsNullOrWhiteSpace(request.Email))
                throw new System.Exception("Parameter 'Email' could not be null or empty");
            if (CheckUCConfig.IsPhoneNumberRequired && string.IsNullOrWhiteSpace(request.PhoneNumber))
                throw new System.Exception("Parameter 'PhoneNumber' could not be null or empty");
            if (CheckUCConfig.IsPasswordRequired && string.IsNullOrWhiteSpace(request.Password))
                throw new System.Exception("Parameter 'Password' could not be null or empty");
            // 
            // Interact with the DB 
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
            if (CheckUCConfig.IsLoginRequired && string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (CheckUCConfig.IsPasswordRequired && string.IsNullOrWhiteSpace(request.Password))
                throw new System.Exception("Parameter 'Password' could not be null or empty");
            // 
            // Interact with the DB
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