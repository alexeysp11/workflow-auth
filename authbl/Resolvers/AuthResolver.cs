using System.Text.Json;
using System.Text.Json.Serialization;
using Cims.WorkflowLib.NetworkApis;
using Cims.WorkflowLib.Models.ErrorHandling;
using Cims.WorkflowLib.Models.Network;
using WokflowLib.Authentication.Models.ConfigParameters;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

/// <summary>
/// Class that processes authentication requests.
/// </summary>
public class AuthResolver
{
    private CheckUCConfig CheckUCConfig { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public AuthResolver()
    {
        CheckUCConfig = ConfigHelper.GetUCConfigs();
    }

    /// <summary>
    /// Method that checks if the specified user exists in the database.
    /// </summary>
    public UserExistance CheckUserExistance(UserCredentials request)
    {
        var response = new UserExistance();
        try
        {
            if (CheckUCConfig.IsLoginRequired && string.IsNullOrWhiteSpace(request.Login))
                throw new System.Exception("Parameter 'Login' could not be null or empty");
            if (CheckUCConfig.IsEmailRequired && string.IsNullOrWhiteSpace(request.Email))
                throw new System.Exception("Parameter 'Email' could not be null or empty");
            if (CheckUCConfig.IsPhoneNumberRequired && string.IsNullOrWhiteSpace(request.PhoneNumber))
                throw new System.Exception("Parameter 'PhoneNumber' could not be null or empty"); 
            // 
            new UserResolver().CheckUserExistance(request, response);
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
            ApiOperation httpResponse = new ApiOperation();
            var task = Task.Run(async () => 
            {
                httpResponse = await new HttpSender().SendAsync("https://localhost:7251/Auth/AddUser", request, "Auth/AddUser");
            });
            task.Wait();
            response = JsonSerializer.Deserialize<UserCreationResult>(httpResponse.Response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
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
    /// Method for verification of sign up completion.
    /// </summary>
    public VSUResponse VerifySignUp(VSURequest request)
    {
        var response = new VSUResponse();
        try
        {
            // Decide if the verification was successful based on the token info from request 
            // Notify other services, that are specified in a config file, about the status of token (verified, not verified)
            // 
            // Call auth backend via http
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
            var responseStr = new HttpSender().Send("https://localhost:7251/Auth/VerifyUserCredentials", request);
            response = JsonSerializer.Deserialize<VUCResponse>(responseStr, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
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

    /// <summary>
    /// Method for getting and/or updating the session token by user UID.
    /// </summary>
    public SessionToken GetTokenByUserUid(TokenRequest request)
    {
        var response = new SessionToken();
        try
        {
            if (string.IsNullOrWhiteSpace(request.UserUid))
                throw new System.Exception("Parameter 'UserUid' could not be null or empty");
            // Update session token for the specified user 
            // 
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